using ETaraba.DTOs.BasketDTOs;
using ETaraba.DTOs.OrderDTOs;

namespace ETaraba.DTOs.UserDTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImgSrc { get; set; }
        public string PhoneNumber { get; set; }
        public int NumberOfOrders
        {
            get
            {
                return Orders.Count;
            }
        }
        public ICollection<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
        public BasketDTO Basket { get; set; }
    }
}
