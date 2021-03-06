using MediatR;
using RefactorThis.Domain.Aggregates.Product.Commands;
using RefactorThis.Domain.Aggregates.Product.Reponses;
using RefactorThis.Domain.Aggregates.Product.Services;
using System.Threading;
using System.Threading.Tasks;

namespace RefactorThis.Domain.Aggregates.Product.Handlers
{
    public class DeleteProductOptionHandler : IRequestHandler<DeleteProductOptionCommand, DeleteProductOptionResponse>
    {
        public IProductService ProductService { get; init; }

        public DeleteProductOptionHandler(IProductService productService)
        {
            ProductService = productService;
        }

        public async Task<DeleteProductOptionResponse> Handle(DeleteProductOptionCommand request, CancellationToken cancellationToken)
        {
            return await ProductService.DeleteProductOption(request);
        }
    }
}
