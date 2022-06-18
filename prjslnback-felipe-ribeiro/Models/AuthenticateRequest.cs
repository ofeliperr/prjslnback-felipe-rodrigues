using System.ComponentModel.DataAnnotations;

namespace prjslnback_felipe_ribeiro.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
