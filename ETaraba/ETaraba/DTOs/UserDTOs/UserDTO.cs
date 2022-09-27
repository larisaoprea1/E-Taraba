using ETaraba.Domain.Models;

namespace ETaraba.DTOs.UserDTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImgSrc { get; set; }
        public string PhoneNumber { get; set; }
    }
}
