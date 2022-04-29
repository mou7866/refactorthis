using RefactorThis.Domain.Product.Models;
using System;

namespace RefactorThis.Domain.Aggregates.Product.Commands
{
    public class UpdateProductCommand
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
