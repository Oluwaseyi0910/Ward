using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RoyalKiddiesWard.API.ViewModels
{
    public class UserLogin
    {
        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }

    }
}
