using AutoMapper;
using ETaraba.Application.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ETaraba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBasketProductRepository _basketProductRepository;
        private readonly IOrderRepository _orderRepository;
        public OrderController(IMapper mapper,
           IBasketProductRepository basketProductRepository,
           IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _basketProductRepository = basketProductRepository ?? throw new ArgumentNullException(nameof(basketProductRepository));
        }
       
    }
}
