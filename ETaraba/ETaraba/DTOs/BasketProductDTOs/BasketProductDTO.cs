using ETaraba.DTOs.ProductDTOs;

namespace ETaraba.DTOs.BasketProductDTOs
{
    public class BasketProductDTO
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ProductDTO Product { get; set; } 
    }
}
