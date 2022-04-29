using RefactorThis.Domain.Product.Models;
using System;

namespace RefactorThis.Domain.Aggregates.Product.Commands
{
    public class CreateProductOptionCommand
    {
        public CreateProductOptionCommand(Guid productId, ProductOptionModel option)
        {
            ProductId = productId;
            Option = option;
        }
                
        public Guid ProductId { get; }

        public ProductOptionModel Option { get; }
    }
}
