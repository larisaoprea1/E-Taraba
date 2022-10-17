using ETaraba.DTOs.ProductDTOs;

namespace ETaraba.DTOs.OrderProductDTOs
{
    public class OrderProductDTO
    {
        public Guid Id { get; set; }
        public ProductDTO Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
