namespace ETaraba.Domain.Models
{
    public class Basket : BaseModel
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<BasketProduct> BasketProducts { get; set; }
    }
}