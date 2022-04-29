using Microsoft.EntityFrameworkCore;
using RefactorThis.Data.Models;
using System.Reflection;

namespace RefactorThis.Data
{
    public partial class RefactorThisDbContext : DbContext
    {
        public RefactorThisDbContext()
        {
        }

        public RefactorThisDbContext(DbContextOptions<RefactorThisDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProductEntity> Products { get; set; }
        public virtual DbSet<ProductOptionEntity> ProductOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
