using AutoMapper;
using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using ETaraba.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETaraba.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await _productRepository.GetProductAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProductDTO>(product));
        }
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateProduct(ProductForCreationDTO product)
        {
            var productToCreate = new Product
            {
                Name = product.Name,
                Description = product.Description,
                ProductPhoto= product.ProductPhoto,
                Quantity= product.Quantity,
                Price = product.Price
            };
            await _productRepository.CreateProductAsync(productToCreate);
            await _productRepository.SaveAsync();
            var createdProductToReturn = _mapper.Map<ProductDTO>(productToCreate);
            return Ok(createdProductToReturn);
        }
    }
}
