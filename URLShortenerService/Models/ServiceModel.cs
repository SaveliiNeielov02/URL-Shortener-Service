using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace URLShortenerService.Models
{
    public class Role
    {
        [Key]
        public int ID { get; set; }
        public string RoleName { get; set; }
    }
    public class User
    {
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
        [ForeignKey("RoleID")]
        public int RoleID { get; set; }
    }
    public class Record
    {
        [Key]
        [JsonPropertyName("ShortURL")]
        public string? ShortURL { get; set; }
        [JsonPropertyName("LongURL")]
        public string LongURL { get; set; }
        [ForeignKey("UserLogin")]
        [JsonPropertyName("UserLogin")]
        public string UserLogin { get; set; }
        [JsonPropertyName("CreatedDate")]
        public DateTime CreatedDate { get; set; }
    }
}
