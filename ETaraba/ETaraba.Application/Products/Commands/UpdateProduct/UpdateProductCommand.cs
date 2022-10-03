using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductPhoto { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
