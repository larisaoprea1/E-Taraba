using AutoMapper;
using ETaraba.Application.Baskets.Commands.AddProductToBasket;
using ETaraba.Application.Baskets.Commands.DeleteBasketProduct;
using ETaraba.Application.Baskets.Querries.GetBasketProducts;
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
        public async Task<IActionResult> GetBasketProducts()
        {
            var result = await _mediator.Send(new GetBasketProductsQuery());
            var mappedResult = _mapper.Map<IEnumerable<BasketProductDTO>>(result);
            return Ok(mappedResult);

        }
        [HttpPost]
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
