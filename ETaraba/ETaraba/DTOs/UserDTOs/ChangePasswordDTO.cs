using System.ComponentModel.DataAnnotations;

namespace ETaraba.DTOs.UserDTOs
{
    public class ChangePasswordDTO
    {
        [DataType(DataType.Password), Required(ErrorMessage = "Old Password Required")]
        public string oldPassword { get; set; }

        [DataType(DataType.Password), Required(ErrorMessage = "New Password Required")]
        public string newPassword { get; set; }
    }
}
