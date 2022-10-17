﻿using AutoMapper;
using ETaraba.Application.Baskets.Commands.AddProductToBasket;
using ETaraba.Application.Baskets.Commands.DeleteBasketProduct;
using ETaraba.Application.Baskets.Querries.GetBasketById;
using ETaraba.Application.Baskets.Querries.GetBasketsProducts;
using ETaraba.DTOs.BasketDTOs;
using ETaraba.DTOs.BasketProductDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETaraba.Controllers
{
    [Route("api/basket")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BasketController(
            IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpGet]
        [Route("basketproducts")]
        public async Task<IActionResult> GetBasketsProducts()
        {
            var result = await _mediator.Send(new GetBasketsProductsQuery());
            var mappedResult = _mapper.Map<IEnumerable<BasketProductDTO>>(result);
            return Ok(mappedResult);

        }
        [HttpGet]
        [Route("{basketId}")]
        public async Task<IActionResult> GetBasket([FromRoute] Guid basketId)
        {
            var result = await _mediator.Send(new GetBasketByIdQuery
            {
                Id = basketId
            });
            if (result == null)
            {
                return NotFound("404");
            }
            return Ok(_mapper.Map<BasketDTO>(result));
        }
        [HttpPost]
        [Route("user/{userId}/product/{productId}/count/{count}")]
        public async Task<IActionResult> AddProductToBasket(Guid userId, Guid productId, int count)
        {
            await _mediator.Send(new AddProductToBasketCommand
            {
                UserId = userId,
                ProductId = productId,
                Count = count
            });
            return Ok("200");
        }
        [HttpDelete("{basketProductId}")]
        public async Task<ActionResult> DeleteBasketProduct(Guid basketProductId)
        {
            await _mediator.Send(new DeleteBasketProductCommand
            {
                Id = basketProductId
            });
            return Ok("200");
        }
    }
}
