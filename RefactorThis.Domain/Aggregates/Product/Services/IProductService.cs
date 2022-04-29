using RefactorThis.Domain.Aggregates.Product.Commands;
using RefactorThis.Domain.Aggregates.Product.Reponses;
using System.Threading.Tasks;

namespace RefactorThis.Domain.Aggregates.Product.Services
{
    public interface IProductService
    {
        Task<CreateProductResponse> CreateProduct(CreateProductCommand request);
    }
}
