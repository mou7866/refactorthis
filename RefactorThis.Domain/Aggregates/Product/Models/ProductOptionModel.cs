﻿using System;

namespace RefactorThis.Domain.Product.Models
{
    public class ProductOptionModel
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}