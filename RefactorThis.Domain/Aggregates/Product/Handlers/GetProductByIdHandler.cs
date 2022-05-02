using MediatR;
using RefactorThis.Domain.Aggregates.Product.Queries;
using RefactorThis.Domain.Aggregates.Product.Responses;
using RefactorThis.Domain.Aggregates.Product.Services;
using System.Threading;
using System.Threading.Tasks;

namespace RefactorThis.Domain.Aggregates.Product.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdResponse>
    {
        public IProductService ProductService { get; init; }

        public GetProductByIdHandler(IProductService productService)
        {
            ProductService = productService;
        }

        public async Task<GetProductByIdResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await ProductService.GetProductById(request);
        }
    }
}
