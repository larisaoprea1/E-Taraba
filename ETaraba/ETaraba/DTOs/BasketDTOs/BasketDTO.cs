using ETaraba.DTOs.BasketProductDTOs;

namespace ETaraba.DTOs.BasketDTOs
{
    public class BasketDTO
    {
        public Guid Id { get; set; }  
        public int NumberOfBasketProducts
        {
            get
            {
                return BasketProducts.Count;
            }
        }
        public ICollection<BasketProductDTO> BasketProducts { get; set; } = new List<BasketProductDTO>();
    }
}
