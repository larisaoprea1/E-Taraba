using MediatR;

namespace ETaraba.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand :IRequest
    {
        public Guid Id { get; set; }    
    }
}
