﻿using System;
using System.Collections.Generic;

namespace RefactorThis.Data.Models
{
    public class ProductEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<ProductOptionEntity> ProductOptions { get; set; }
    }
}
