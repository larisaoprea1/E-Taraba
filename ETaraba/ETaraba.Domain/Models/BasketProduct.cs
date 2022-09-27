namespace ETaraba.Domain.Models
{
    public class BasketProduct : Entity
    {
        public Guid BasketId { get; set; }
        public Basket Basket { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

    }
}