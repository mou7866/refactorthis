using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RefactorThis.Data.Models;

namespace RefactorThis.Data.Configuration
{
    internal class ProductOptionConfiguration : IEntityTypeConfiguration<ProductOptionEntity>
    {
        public void Configure(EntityTypeBuilder<ProductOptionEntity> builder)
        {
            builder.HasIndex(e => e.Id, "ix_productoption_id")
                .IsUnique();

            builder
                .Property(e => e.Id)
                .ValueGeneratedOnAdd(); 

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasOne(d => d.Product)
               .WithMany(p => p.ProductOptions)
               .HasForeignKey(d => d.ProductId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
