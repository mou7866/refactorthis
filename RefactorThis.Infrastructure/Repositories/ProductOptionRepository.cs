using RefactorThis.Data.Models;
using RefactorThis.Infrastructure.Repositories;

namespace RefactorThis.Data.Repositories
{
    public class ProductOptionRepository : GenericRepository<ProductOptionEntity>, IProductOptionRepository
    {
        public ProductOptionRepository(RefactorThisDbContext context) : base(context)
        {
        }
    }
}
