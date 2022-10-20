using AutoMapper;
using ETaraba.Application.Baskets.Commands.AddProductToBasket;
using ETaraba.Application.Baskets.Commands.DeleteBasketProduct;
using ETaraba.Application.Baskets.Commands.SaveBasketProduct;
using ETaraba.Application.Baskets.Querries.GetBasketById;
using ETaraba.Application.Baskets.Querries.GetBasketProductById;
using ETaraba.Application.Baskets.Querries.GetBasketsProducts;
using ETaraba.Application.IRepositories;
using ETaraba.DTOs.BasketDTOs;
using ETaraba.DTOs.BasketProductDTOs;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ETaraba.Controllers
{
    [Route("api/basket")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBasketProductRepository _basketProductRepository;

        public BasketController(
            IMediator mediator, IMapper mapper, IBasketProductRepository basketProductRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _basketProductRepository = basketProductRepository; 
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
        [HttpPatch]
        [Route("updatequantity/{basketProductId}")]
        public async Task<IActionResult> UpdateBasketProductQuantity(Guid basketProductId, JsonPatchDocument<BasketProductQuantityUpdateDTO> patchDocument)
        {
            var basketProductToFind = await _mediator.Send(new GetBasketProductByIdQuery
            {
                Id = basketProductId
            });
            if (basketProductToFind == null)
            {
                return NotFound("404");
            }
            var basketProductToPatch = _mapper.Map<BasketProductQuantityUpdateDTO>(basketProductToFind);
            patchDocument.ApplyTo(basketProductToPatch, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(basketProductToPatch))
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(basketProductToPatch, basketProductToFind);
            await _mediator.Send(new SaveBasketProductCommand());
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
