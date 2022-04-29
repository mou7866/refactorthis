using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RefactorThis.Data.Models;

namespace RefactorThis.Data.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasIndex(e => e.Id, "ix_product_id")
                .IsUnique();

            builder
                .Property(e => e.Id)
                .ValueGeneratedOnAdd(); 

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
