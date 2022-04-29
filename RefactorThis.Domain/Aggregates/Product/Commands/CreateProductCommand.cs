﻿namespace RefactorThis.Domain.Aggregates.Product.Commands
{
    public class CreateProductCommand
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }
    }
}
