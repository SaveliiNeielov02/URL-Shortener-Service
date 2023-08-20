using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;
using URLShortenerService.Models;
using Newtonsoft.Json;
using System.Collections;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using System.Web;

namespace URLShortenerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlServiceController : ControllerBase
    {
        private readonly ModelDBContext _context;
        private readonly ShortenUrlService _shortenUrl;

        public UrlServiceController(ModelDBContext context, ShortenUrlService shortenUrl)
        {
            _context = context;
            _shortenUrl = shortenUrl;
            /*_context.Roles.Add(new Role { ID = _context.Roles.Count() + 1, RoleName = "Admin" });
            _context.SaveChanges();
            _context.Roles.Add(new Role { ID = _context.Roles.Count() + 1, RoleName = "Ordinary" });
            _context.SaveChanges();*/
        }

        [HttpGet("Authorize/{login}/{password}")]
        public async Task<IActionResult> Authorize(string login, string password)
        {
            Role? role = login.StartsWith("Admin")
                ? await _context.Roles.FirstOrDefaultAsync(_ => _.RoleName == "Admin")
                : await _context.Roles.FirstOrDefaultAsync(_ => _.RoleName == "Ordinary");

            if (await _context.Users.FirstOrDefaultAsync(_ => _.Login == login) == default)
            {
                await _context.AddAsync(
                    new User { Login = login, Password = password, RoleID = role.ID });
                await _context.SaveChangesAsync();
            }
            else
            {
                if (await _context.Users.FirstOrDefaultAsync(_ => _.Login == login && _.Password == password) == default)
                {
                    return BadRequest(new { message = "Incorrect password" });
                }
            }

            return Ok(new { roleName = role.RoleName });
        }
        [HttpGet("GetRecords")]
        public async Task<IEnumerable<Record>> GetRecords()
        {
            return await _context.Records.ToListAsync();
        }

        [HttpPost("ShortenURL")]
        public async Task<IActionResult> ShortenLink([FromBody] Record data)
        {
            var shortenString = _shortenUrl.ShortenUrl(data.LongURL);
            if (await _context.Records.FirstOrDefaultAsync(_ => _.ShortURL == shortenString) == default)
            {
                await _context.Records.AddAsync(
                        new Record
                        {
                            LongURL = data.LongURL,
                            UserLogin = data.UserLogin,
                            CreatedDate = data.CreatedDate,
                            ShortURL = shortenString,
                        }
                    );
                await _context.SaveChangesAsync();
            }
            else 
            {
                return BadRequest(new { message = "URL has been already added" });
            }
            
            return Ok();
        }

        [HttpDelete("DeleteRecord/{shortURL}")]
        public async Task<IActionResult> DeleteRecord(string shortURL)
        {
            string decodedShortURL = HttpUtility.UrlDecode(shortURL);
            _context.Records.Remove(
                await _context.Records.FirstOrDefaultAsync(_ => _.ShortURL == decodedShortURL)
                );
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("GetRecordByURL/{shortURL}")]
        public async Task<Record> GetRecordByURL(string shortURL)
        {
            string decodedShortURL = HttpUtility.UrlDecode(shortURL);
            return await _context.Records.FirstOrDefaultAsync(_ => _.ShortURL == decodedShortURL);
        }

        [HttpDelete("DeleteAllRecords")]
        public async Task<IActionResult> DeleteAllRecords()
        {
            _context.Records.RemoveRange(_context.Records);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}