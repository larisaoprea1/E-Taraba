using System.ComponentModel.DataAnnotations;

namespace ETaraba.DTOs.UserDTOs
{
    public class ChangePasswordDTO
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [DataType(DataType.Password), Required(ErrorMessage = "Old Password Required")]
        public string oldPassword { get; set; }

        [DataType(DataType.Password), Required(ErrorMessage = "New Password Required")]
        public string newPassword { get; set; }
    }
}
