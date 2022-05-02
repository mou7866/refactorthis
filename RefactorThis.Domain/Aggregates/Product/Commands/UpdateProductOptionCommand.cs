using MediatR;
using RefactorThis.Domain.Aggregates.Product.Reponses;
using RefactorThis.Domain.Product.Models;
using System;

namespace RefactorThis.Domain.Aggregates.Product.Commands
{
    public class UpdateProductOptionCommand : IRequest<UpdateProductOptionResponse>
    {
        public UpdateProductOptionCommand(Guid productId, Guid id, ProductOptionModel option)
        {
            ProductId = productId;
            Id = id;
            Option = option;
        }
                
        public Guid ProductId { get; }

        public Guid Id { get; }

        public ProductOptionModel Option { get; }
    }
}
