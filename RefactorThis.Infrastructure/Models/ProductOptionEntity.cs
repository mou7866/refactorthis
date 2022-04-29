using System;

namespace RefactorThis.Data.Models
{
    public class ProductOptionEntity
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public virtual ProductEntity Product { get; set; }
    }
}
