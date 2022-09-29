using AutoMapper;
using ETaraba.Application.IRepositories;
using ETaraba.Application.Products.Commands.CreateProduct;
using ETaraba.Application.Products.Querries.GetAllProducts;
using ETaraba.Application.Products.Querries.GetProductById;
using ETaraba.Domain.Models;
using ETaraba.DTOs.ProductDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ETaraba.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductController(IProductRepository productRepository, IMapper mapper,IMediator mediator)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
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
                return NotFound();
            }
            return Ok(_mapper.Map<ProductDTO>(result));
        }
        [HttpPost]
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
        [HttpPut("{productId}")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(Guid productId, ProductForUpdatingDTO product)
        {
            if(!await _productRepository.GetIfProductExistsAsync(productId))
            {
                return NotFound();
            }
            var productFromStore = await _productRepository.GetProductAsync(productId);
            if (productFromStore == null)
            {
                return NotFound();
            }
            var content =_mapper.Map(product, productFromStore);
            await _productRepository.SaveAsync();

            return Ok(content);
        }
        [HttpDelete("{productId}")]
        public async Task<ActionResult> DeleteProduct(Guid productId)
        {
            if (!await _productRepository.GetIfProductExistsAsync(productId))
            {
                return NotFound();
            }
           var productToDelete = await _productRepository.GetProductAsync(productId);
            if(productToDelete == null)
            {
                return NotFound();
            }
            _productRepository.DeleteProduct(productToDelete);
            await _productRepository.SaveAsync();
            return Ok("The item has been deleted");
        }
    }
}
