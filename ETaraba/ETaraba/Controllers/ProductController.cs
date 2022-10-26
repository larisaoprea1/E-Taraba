using AutoMapper;
using ETaraba.Application.Products.Commands.CreateProduct;
using ETaraba.Application.Products.Commands.DeleteProduct;
using ETaraba.Application.Products.Commands.UpdateProduct;
using ETaraba.Application.Products.Querries.GetAllProducts;
using ETaraba.Application.Products.Querries.GetProductById;
using ETaraba.Domain.Models;
using ETaraba.DTOs.ProductDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETaraba.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductController(IMapper mapper,IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] string? searchProduct)
        {
            var result = await _mediator.Send(new GetAllProductsQuery
            {
                SearchString = searchProduct
            });
            var products = _mapper.Map<IEnumerable<ProductDTO>>(result);
            return Ok(products);
        }
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct([FromRoute]Guid productId)
        {
            var result = await _mediator.Send(new GetProductByIdQuery
            {
                Id = productId
            });
            if(result == null)
            {
                return NotFound("404");
            }
            return Ok(_mapper.Map<ProductDTO>(result));
        }
        [HttpPost]
        [Route("addproduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductForCreationDTO product)
        {  
            var productToCreate = new Product
            {
                Name = product.Name,
                Description = product.Description,
                ProductPhoto= product.ProductPhoto,
                Quantity= product.Quantity,
                Price = product.Price
            };
            var result = await _mediator.Send(new CreateProductCommand
            {
                Product = productToCreate
            });
            var createdProductToReturn = _mapper.Map<ProductDTO>(result);
            return CreatedAtAction(nameof(GetProduct), new { productId = createdProductToReturn.Id }, createdProductToReturn);
        }
        [HttpPut]
        [Route("updateproduct/{productId}")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct([FromRoute] Guid productId, ProductForUpdatingDTO product)
        {
            var result = await _mediator.Send(new UpdateProductCommand
            {
                Id= productId,
                Name = product.Name,    
                Description = product.Description,
                ProductPhoto = product.ProductPhoto,    
                Price = product.Price,
                Quantity= product.Quantity
            });
            if(result == null)
            {
                NotFound("404");
            }
            var mapResult = _mapper.Map<ProductDTO>(result);
            return Ok(mapResult);
        }
        [HttpDelete]
        [Route("deleteproduct/{productId}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid productId)
        {
            await _mediator.Send(new DeleteProductCommand
            {
                Id = productId
            });
            return Ok("200");
        }
    }
}
