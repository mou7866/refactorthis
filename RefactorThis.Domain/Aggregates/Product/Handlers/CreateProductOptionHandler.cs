using MediatR;
using RefactorThis.Domain.Aggregates.Product.Commands;
using RefactorThis.Domain.Aggregates.Product.Queries;
using RefactorThis.Domain.Aggregates.Product.Reponses;
using RefactorThis.Domain.Aggregates.Product.Responses;
using RefactorThis.Domain.Aggregates.Product.Services;
using System.Threading;
using System.Threading.Tasks;

namespace RefactorThis.Domain.Aggregates.Product.Handlers
{
    public class CreateProductOptionHandlerHandler : IRequestHandler<CreateProductOptionCommand, CreateProductOptionResponse>
    {
        public IProductService ProductService { get; init; }

        public CreateProductOptionHandlerHandler(IProductService productService)
        {
            ProductService = productService;
        }

        public async Task<CreateProductOptionResponse> Handle(CreateProductOptionCommand request, CancellationToken cancellationToken)
        {
            return await ProductService.CreateProductOption(request);
        }
    }
}
