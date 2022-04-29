using RefactorThis.Data.Models;
using RefactorThis.Infrastructure.Repositories;

namespace RefactorThis.Data.Repositories
{
    public class ProductRepository : GenericRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(RefactorThisDbContext context) : base(context)
        {
        }
    }
}
