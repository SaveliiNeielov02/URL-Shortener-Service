import { Component} from '@angular/core';



@Component({
  selector: 'about-component',
  templateUrl: './about.component.html'
})
export class AboutComponent {
  CSharpCode = `
    public class ShortenUrlService
    {
      private const string BaseUrl = "http://localhost:44441/shorten/";

      private string GenerateShortCode(string longUrl)
      {
       using (var md5 = MD5.Create())
       {
        var hashBytes = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(longUrl));
        var hashCode = BitConverter.ToUInt64(hashBytes, 0);
        return Convert.ToBase64String(BitConverter.GetBytes(hashCode))
        .Replace("/", "_").Replace("+", "-").Substring(0, 6);
        }
       }

      public string ShortenUrl(string longUrl)
      {
        var shortCode = GenerateShortCode(longUrl);
        return BaseUrl + shortCode;
      }
    }
  `;
  updateCode(newCode: string) {
    this.CSharpCode = newCode;
  }

}
