using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Registr
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string Password { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 4)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
