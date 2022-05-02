using MediatR;
using RefactorThis.Domain.Aggregates.Product.Reponses;
using System;

namespace RefactorThis.Domain.Aggregates.Product.Commands
{
    public class DeleteProductOptionCommand : IRequest<DeleteProductOptionResponse>
    {
        public DeleteProductOptionCommand(Guid productId, Guid id)
        {
            ProductId = productId;
            Id = id;
        }

        public Guid ProductId { get; set; }
        public Guid Id { get; set; }
    }
}
