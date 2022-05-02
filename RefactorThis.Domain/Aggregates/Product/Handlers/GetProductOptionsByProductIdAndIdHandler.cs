using MediatR;
using RefactorThis.Domain.Aggregates.Product.Queries;
using RefactorThis.Domain.Aggregates.Product.Responses;
using RefactorThis.Domain.Aggregates.Product.Services;
using System.Threading;
using System.Threading.Tasks;

namespace RefactorThis.Domain.Aggregates.Product.Handlers
{
    public class GetProductOptionsByProductIdAndIdHandler : IRequestHandler<GetProductOptionsByProductIdAndIdQuery, GetProductOptionsByProductIdAndIdResponse>
    {
        public IProductService ProductService { get; init; }

        public GetProductOptionsByProductIdAndIdHandler(IProductService productService)
        {
            ProductService = productService;
        }

        public async Task<GetProductOptionsByProductIdAndIdResponse> Handle(GetProductOptionsByProductIdAndIdQuery request, CancellationToken cancellationToken)
        {
            return await ProductService.GetProductOptionByProductIdAndId(request);
        }
    }
}
