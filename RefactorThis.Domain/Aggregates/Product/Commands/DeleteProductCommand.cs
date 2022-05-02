using MediatR;
using RefactorThis.Domain.Aggregates.Product.Reponses;
using System;

namespace RefactorThis.Domain.Aggregates.Product.Commands
{
    public class DeleteProductCommand : IRequest<DeleteProductResponse>
    {
        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
