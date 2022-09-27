using System.ComponentModel.DataAnnotations.Schema;

namespace ETaraba.Domain.Models
{
    public class OrderProduct : BaseModel
    {
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
        public Product Product { get; }
        public Guid ProductId { get; set; }
    }
}