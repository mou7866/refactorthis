using AutoMapper;
using RefactorThis.Data.Models;
using RefactorThis.Data.Repositories;
using RefactorThis.Domain.Aggregates.Product.Commands;
using RefactorThis.Domain.Aggregates.Product.Queries;
using RefactorThis.Domain.Aggregates.Product.Reponses;
using RefactorThis.Domain.Aggregates.Product.Responses;
using RefactorThis.Domain.Product.Models;
using RefactorThis.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefactorThis.Domain.Aggregates.Product.Services
{
    public class ProductService : IProductService
    {
        public IProductRepository ProductRepository { get; init; }
        public IMapper Mapper { get; init; }
        public IUnitOfWork UnitOfWork { get; init; }

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            ProductRepository = unitOfWork.GetRepository<IProductRepository>();
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }
        public async Task<CreateProductResponse> CreateProduct(CreateProductCommand request)
        {
            await ProductRepository.Add(Mapper.Map<ProductEntity>(request));
            await UnitOfWork.Commit();

            return new CreateProductResponse();
        }

        public async Task<GetAllProductsResponse> GetAllProducts(GetAllProductsQuery request)
        {
            var products = await ProductRepository.Get();
            return new GetAllProductsResponse()
            {
                Data = new()
                {
                    Items = Mapper.Map<List<ProductModel>>(products)
                }
            };

        }

        public async Task<GetProductByNameResponse> GetProductByName(GetProductByNameQuery request)
        {
            var products = await ProductRepository.Get(x => x.Name == request.Name);
            return new GetProductByNameResponse()
            {
                Data = new()
                {
                    Items = Mapper.Map<List<ProductModel>>(products)
                }
            };
        }

        public async Task<GetProductByIdResponse> GetProductById(GetProductByIdQuery request)
        {
            var products = await ProductRepository.Get(x => x.Id == request.Id);
            return new GetProductByIdResponse()
            {
                Data = new()
                {
                    Items = Mapper.Map<List<ProductModel>>(products)
                }
            };
        }

        public async Task<UpdateProductResponse> UpdateProduct(UpdateProductCommand request)
        {
            var product = await ProductRepository.Get(x => x.Id == request.Id);

            if (product is null)
            {
                return new()
                {
                    Errors = new()
                    {
                        new()
                        {
                            Code = "not_found",
                            Message = "Product not found",
                            Type = Seedwork.ResponseType.FAILURE
                        }
                    }
                };
            }

            await ProductRepository.Update(Mapper.Map<ProductEntity>(request));
            await UnitOfWork.Commit();

            return new();
        }

        public async Task<DeleteProductResponse> DeleteProduct(DeleteProductCommand request)
        {
            var product = await ProductRepository.Get(x => x.Id == request.Id);

            if (product is null)
            {
                return new()
                {
                    Errors = new()
                    {
                        new()
                        {
                            Code = "not_found",
                            Message = "Product not found",
                            Type = Seedwork.ResponseType.FAILURE
                        }
                    }
                };
            }
            else
            {
                var productToUpdate = product.First();
                productToUpdate.IsActive = false;
                await ProductRepository.Update(productToUpdate);
                await UnitOfWork.Commit();

            }            

            return new();
        }
    }
}
