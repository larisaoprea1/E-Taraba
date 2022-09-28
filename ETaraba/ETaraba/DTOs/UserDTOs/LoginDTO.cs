using System.ComponentModel.DataAnnotations;

namespace ETaraba.DTOs.UserDTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddressAttribute]
        public string Email { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
