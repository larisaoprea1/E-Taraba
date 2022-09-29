using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Product>
    {
        public Product Product { get; set; }
    }
}
