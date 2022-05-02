using MediatR;
using RefactorThis.Domain.Aggregates.Product.Commands;
using RefactorThis.Domain.Aggregates.Product.Reponses;
using RefactorThis.Domain.Aggregates.Product.Services;
using System.Threading;
using System.Threading.Tasks;

namespace RefactorThis.Domain.Aggregates.Product.Handlers
{
    public class UpdateProductOptionHandler : IRequestHandler<UpdateProductOptionCommand, UpdateProductOptionResponse>
    {
        public IProductService ProductService { get; init; }

        public UpdateProductOptionHandler(IProductService productService)
        {
            ProductService = productService;
        }

        public async Task<UpdateProductOptionResponse> Handle(UpdateProductOptionCommand request, CancellationToken cancellationToken)
        {
            return await ProductService.UpdateProductOption(request);
        }
    }
}
