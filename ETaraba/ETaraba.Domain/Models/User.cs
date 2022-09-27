using Microsoft.AspNetCore.Identity;

namespace ETaraba.Domain.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImgSrc { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Basket> Baskets { get; set; }
    }
}
