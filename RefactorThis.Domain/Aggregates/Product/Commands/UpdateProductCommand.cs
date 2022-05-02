using MediatR;
using RefactorThis.Domain.Aggregates.Product.Reponses;
using RefactorThis.Domain.Product.Models;
using System;

namespace RefactorThis.Domain.Aggregates.Product.Commands
{
    public class UpdateProductCommand : IRequest<UpdateProductResponse>
    {
        public UpdateProductCommand(Guid id, ProductModel product)
        {
            Id = id;
            Product = product;
        }

        public Guid Id { get; set; }

        public ProductModel Product { get; }
    }
}
