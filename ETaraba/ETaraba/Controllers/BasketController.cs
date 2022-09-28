using AutoMapper;
using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETaraba.Controllers
{
    [Route("api/basket")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IBasketProductRepository _basketProductRepository;

        public BasketController(IProductRepository productRepository, IMapper mapper, IUserRepository userRepository, IBasketProductRepository basketProductRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));   
            _basketProductRepository = basketProductRepository ?? throw new ArgumentNullException(nameof(basketProductRepository));
        }
        [HttpPost]
        public async Task<IActionResult> AddProductToBasket(Guid userId, Guid productId, int count)
        {
            
            var product = await _productRepository.GetProductAsync(productId);
            var user = await  _userRepository.GetUserAsync(userId);
            var item = new BasketProduct
            {
                BasketId= user.BasketId,
                ProductId = productId,
                Quantity = count,
                Price = product.Price*count
            };
            await _basketProductRepository.AddBasketProductAsync(item);
            await _basketProductRepository.SaveAsync();
            return Content("Item added");
        }
        [HttpDelete("{basketProductId}")]
        public async Task<ActionResult> DeleteBasketProduct(Guid basketProductId)
        { 
           var basketProductToDelete = await _basketProductRepository.GetBasketProductAsync(basketProductId);
            if(basketProductToDelete == null)
            {
                return NotFound();
            }
            _basketProductRepository.DeleteBasketProduct(basketProductToDelete);
            await _productRepository.SaveAsync();
            return Content("The item has been deleted");
        }
    }
}
