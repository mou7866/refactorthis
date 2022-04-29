using RefactorThis.Domain.Aggregates.Product.Commands;
using RefactorThis.Domain.Aggregates.Product.Reponses;
using System.Threading.Tasks;

namespace RefactorThis.Domain.Aggregates.Product.Services
{
    public class ProductService : IProductService
    {
        public Task<CreateProductResponse> CreateProduct(CreateProductCommand request)
        {
            throw new System.NotImplementedException();
        }
    }
}
