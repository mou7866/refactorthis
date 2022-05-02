using RefactorThis.Domain.Aggregates.Product.Commands;
using RefactorThis.Domain.Aggregates.Product.Queries;
using RefactorThis.Domain.Aggregates.Product.Reponses;
using RefactorThis.Domain.Aggregates.Product.Responses;
using System.Threading.Tasks;

namespace RefactorThis.Domain.Aggregates.Product.Services
{
    public interface IProductService
    {
        Task<CreateProductResponse> CreateProduct(CreateProductCommand request);
        Task<GetAllProductsResponse> GetAllProducts(GetAllProductsQuery request);
        Task<GetProductByNameResponse> GetProductByName(GetProductByNameQuery request);
        Task<GetProductByIdResponse> GetProductById(GetProductByIdQuery request);
        Task<UpdateProductResponse> UpdateProduct(UpdateProductCommand request);
        Task<DeleteProductResponse> DeleteProduct(DeleteProductCommand request);
    }
}
