using System;

namespace RefactorThis.Domain.Aggregates.Product.Commands
{
    public class DeleteProductOptionCommand
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
