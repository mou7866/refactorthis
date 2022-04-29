using MediatR;
using RefactorThis.Domain.Aggregates.Product.Responses;
using System;

namespace RefactorThis.Domain.Aggregates.Product.Queries
{
    public class GetProductByIdQuery : IRequest<GetProductByIdResponse>
    {
        public GetProductByIdQuery(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; set; }
    }
}
