using MediatR;
using RefactorThis.Domain.Aggregates.Product.Responses;

namespace RefactorThis.Domain.Aggregates.Product.Queries
{
    public class GetAllProductsQuery : IRequest<GetAllProductsResponse>
    {
    }
}
