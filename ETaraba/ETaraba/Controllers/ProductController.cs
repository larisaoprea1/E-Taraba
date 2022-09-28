using AutoMapper;
using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using ETaraba.DTOs.ProductDTOs;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync()
        {
            var productsToGet = await _productRepository.GetProductsAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDTO>>(productsToGet));
        }
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            var product = await _productRepository.GetProductAsync(productId);
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
            return Content("The item has been deleted");
        }
    }
}
