using System.ComponentModel.DataAnnotations.Schema;

namespace ETaraba.Domain.Models
{
    public class BasketProduct : Entity
    {
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid BasketId { get; set; }
        public Basket Basket { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

    }
}