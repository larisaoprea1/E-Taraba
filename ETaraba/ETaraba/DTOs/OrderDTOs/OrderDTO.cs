using ETaraba.DTOs.OrderProductDTOs;

namespace ETaraba.DTOs.OrderDTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public decimal Total { get; set; }
        public int NumberOfOrderProducts
        {
            get
            {
                return OrderProducts.Count;
            }
        }
        public ICollection<OrderProductDTO> OrderProducts { get; set; } = new List<OrderProductDTO>();
    }
}
