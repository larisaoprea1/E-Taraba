using System.ComponentModel.DataAnnotations.Schema;

namespace ETaraba.Domain.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductPhoto { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
        public ICollection<BasketProduct> BasketProducts { get; set; }
    }
}