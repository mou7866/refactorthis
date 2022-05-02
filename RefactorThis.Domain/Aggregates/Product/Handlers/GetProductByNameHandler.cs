using MediatR;
using RefactorThis.Domain.Aggregates.Product.Queries;
using RefactorThis.Domain.Aggregates.Product.Responses;
using RefactorThis.Domain.Aggregates.Product.Services;
using System.Threading;
using System.Threading.Tasks;

namespace RefactorThis.Domain.Aggregates.Product.Handlers
{
    public class GetProductByNameHandler : IRequestHandler<GetProductByNameQuery, GetProductByNameResponse>
    {
        public IProductService ProductService { get; init; }

        public GetProductByNameHandler(IProductService productService)
        {
            ProductService = productService;
        }

        public async Task<GetProductByNameResponse> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
        {
            return await ProductService.GetProductByName(request);
        }
    }
}
