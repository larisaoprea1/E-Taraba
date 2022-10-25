using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Products.Querries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
        public string? SearchString { get; set; }
    }
}
