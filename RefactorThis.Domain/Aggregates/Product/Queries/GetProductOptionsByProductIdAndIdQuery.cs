using MediatR;
using RefactorThis.Domain.Aggregates.Product.Responses;
using System;

namespace RefactorThis.Domain.Aggregates.Product.Queries
{
    public class GetProductOptionsByProductIdAndIdQuery : IRequest<GetProductByIdResponse>
    {
        public GetProductOptionsByProductIdAndIdQuery(Guid productId, Guid id)
        {
            this.Id = id;
            this.ProductId = productId;
        }

        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
    }
}
