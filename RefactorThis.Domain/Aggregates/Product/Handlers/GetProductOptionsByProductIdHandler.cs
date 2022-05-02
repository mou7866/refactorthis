using MediatR;
using RefactorThis.Domain.Aggregates.Product.Queries;
using RefactorThis.Domain.Aggregates.Product.Responses;
using RefactorThis.Domain.Aggregates.Product.Services;
using System.Threading;
using System.Threading.Tasks;

namespace RefactorThis.Domain.Aggregates.Product.Handlers
{
    public class GetProductOptionsByProductIdHandler : IRequestHandler<GetProductOptionsByProductIdQuery, GetProductOptionsByProductIdResponse>
    {
        public IProductService ProductService { get; init; }

        public GetProductOptionsByProductIdHandler(IProductService productService)
        {
            ProductService = productService;
        }

        public async Task<GetProductOptionsByProductIdResponse> Handle(GetProductOptionsByProductIdQuery request, CancellationToken cancellationToken)
        {
            return await ProductService.GetAllProductOptions(request);
        }
    }
}
