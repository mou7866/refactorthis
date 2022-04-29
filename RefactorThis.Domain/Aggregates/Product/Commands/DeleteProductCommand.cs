using System;

namespace RefactorThis.Domain.Aggregates.Product.Commands
{
    public class DeleteProductCommand
    {
        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
