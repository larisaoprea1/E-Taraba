using AutoMapper;
using ETaraba.Application.Orders.Commands.CreateOrder;
using ETaraba.Application.Orders.Querries.GetOrderById;
using ETaraba.Application.Orders.Querries.GetOrdersForUser;
using ETaraba.Domain.Models;
using ETaraba.DTOs.OrderDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETaraba.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public OrderController(IMapper mapper,
            IMediator mediator
           )
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet]
        [Route("{orderId}")]
        public async Task<IActionResult> GetOrder([FromRoute] Guid orderId)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery
            {
                Id = orderId
            });
            if (result == null)
            {
                return NotFound("404");
            }
            return Ok(_mapper.Map<OrderDTO>(result));
        }
        [HttpGet]
        [Route("orders/{userId}")]
        public async Task<IActionResult> GetOrdersForUser([FromRoute] Guid userId)
        {
            var result = await _mediator.Send(new GetOrdersForUserQuery
            {
                Id = userId
            });
            if (result == null)
            {
                return NotFound("404");
            }
            var mappedResult = _mapper.Map<IEnumerable<OrderDTO>>(result);
            return Ok(mappedResult);
        }
        [HttpPost]
        [Route("saveorder/user/{Id}")]
        public async Task<IActionResult> CreateOrder(Guid Id, OrderForCreateDTO orderForCreateDTO)
        {
            var order = new Order
            {
                FirstName = orderForCreateDTO.FirstName,
                LastName = orderForCreateDTO.LastName,  
                PhoneNumber = orderForCreateDTO.PhoneNumber,
                Address = orderForCreateDTO.Address,
                Email = orderForCreateDTO.Email,
                City = orderForCreateDTO.City,
                Country = orderForCreateDTO.Country,
            };
            var result =await _mediator.Send(new CreateOrderCommand
            {
                UserId = Id,
                Order = order
            });
            var orderCreated = _mapper.Map<OrderDTO>(result);
            return Ok(orderCreated);
        }
       
    }
}
