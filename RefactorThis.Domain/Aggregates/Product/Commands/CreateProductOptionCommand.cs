using MediatR;
using RefactorThis.Domain.Aggregates.Product.Reponses;
using RefactorThis.Domain.Product.Models;
using System;

namespace RefactorThis.Domain.Aggregates.Product.Commands
{
    public class CreateProductOptionCommand : IRequest<CreateProductOptionResponse>
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
