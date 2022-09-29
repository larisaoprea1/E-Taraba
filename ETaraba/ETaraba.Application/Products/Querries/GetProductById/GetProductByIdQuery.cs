using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Products.Querries.GetProductById
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public Guid Id { get; set; }
    }
}
