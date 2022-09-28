using System.ComponentModel.DataAnnotations;

namespace ETaraba.DTOs.UserDTOs
{
    public class RegisterDTO
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [EmailAddressAttribute]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        [Required]
        [UrlAttribute]
        public string ProfileImageSrc { get; set; }
    }
}
