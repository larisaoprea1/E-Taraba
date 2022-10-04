using AutoMapper;
using ETaraba.Application.IRepositories;
using ETaraba.Application.Orders.Commands.CreateOrder;
using ETaraba.Domain.Models;
using ETaraba.DTOs.OrderDTOs;
using ETaraba.DTOs.ProductDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ETaraba.Controllers
{
    [Route("api/[controller]")]
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
        [HttpPost]
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
