using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IOrderProductRepository _orderProductRepository;
        public CreateOrderCommandHandler(IUserRepository userRepository, IOrderRepository orderRepository, IBasketRepository basketRepository, IOrderProductRepository orderProductRepository)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _basketRepository = basketRepository;
            _orderProductRepository = orderProductRepository;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserAsync(request.UserId);
            var basket = await _basketRepository.GetBasketAsync(user.BasketId);
            var order = new Order
            {
                FirstName = request.Order.FirstName,
                LastName = request.Order.LastName,
                Address = request.Order.Address,
                PhoneNumber = request.Order.PhoneNumber,
                Email = request.Order.Email,
                City = request.Order.City,
                Country = request.Order.Country,
                Total = 0,
                User = user,
                UserId = request.UserId
            };
            decimal orderTotal = 0;
            await _orderRepository.CreateOrderAsync(order);
            foreach (var basketProduct in basket.BasketProducts)
            {
                var orderProduct = new OrderProduct
                {
                    ProductId = basketProduct.ProductId,
                    Product = basketProduct.Product,
                    OrderId = order.Id,
                    Order = order,
                    Quantity = basketProduct.Quantity,
                    Price = basketProduct.Price
                };
                orderTotal += basketProduct.Price;
                await _orderProductRepository.AddOrderProductAsync(orderProduct);
            }
            order.Total = orderTotal;
            basket.BasketProducts.Clear();
            await _orderProductRepository.SaveAsync();
            return order;
        }
    }
}
