using System.ComponentModel.DataAnnotations.Schema;

namespace ETaraba.Domain.Models
{
    public class Order : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Total { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }

    }
}