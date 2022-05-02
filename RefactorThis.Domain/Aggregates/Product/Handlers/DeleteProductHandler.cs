using MediatR;
using RefactorThis.Domain.Aggregates.Product.Commands;
using RefactorThis.Domain.Aggregates.Product.Reponses;
using RefactorThis.Domain.Aggregates.Product.Services;
using System.Threading;
using System.Threading.Tasks;

namespace RefactorThis.Domain.Aggregates.Product.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
    {
        public IProductService ProductService { get; init; }

        public DeleteProductHandler(IProductService productService)
        {
            ProductService = productService;
        }

        public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await ProductService.DeleteProduct(request);
        }
    }
}
