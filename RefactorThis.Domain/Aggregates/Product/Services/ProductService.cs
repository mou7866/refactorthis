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
        public IProductOptionRepository ProductOptionRepository { get; init; }
        public IMapper Mapper { get; init; }
        public IUnitOfWork UnitOfWork { get; init; }

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            ProductRepository = unitOfWork.GetRepository<IProductRepository>();
            ProductOptionRepository = unitOfWork.GetRepository<IProductOptionRepository>();
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

            if (product is null || !product.Any())
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

            if (product is null || !product.Any())
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

        public async Task<GetProductOptionsByProductIdResponse> GetAllProductOptions(GetProductOptionsByProductIdQuery request)
        {
            var productOptions = await ProductOptionRepository.Get(x => x.ProductId == request.Id);
            return new GetProductOptionsByProductIdResponse()
            {
                Data = new()
                {
                    Items = Mapper.Map<List<ProductOptionModel>>(productOptions)
                }
            };
        }

        public async Task<CreateProductOptionResponse> CreateProductOption(CreateProductOptionCommand request)
        {
            var product = await ProductRepository.Get(x => x.Id == request.ProductId);

            if (product is null || !product.Any())
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
                await ProductOptionRepository.Add(Mapper.Map<ProductOptionEntity>(request));
                await UnitOfWork.Commit();

            }

            return new();
        }

        public async Task<GetProductOptionsByProductIdAndIdResponse> GetProductOptionByProductIdAndId(GetProductOptionsByProductIdAndIdQuery request)
        {
            var productOptions = await ProductOptionRepository.Get(x => x.ProductId == request.ProductId && x.Id == request.Id);

            if (productOptions is null || !productOptions.Any())
            {
                return new()
                {
                    Errors = new()
                    {
                        new()
                        {
                            Code = "not_found",
                            Message = "Product option not found",
                            Type = Seedwork.ResponseType.FAILURE
                        }
                    }
                };
            }
            else
            {
                var productOption = productOptions.First();
                return new GetProductOptionsByProductIdAndIdResponse()
                {
                    Data = Mapper.Map<ProductOptionModel>(productOption)
                };
            }            
        }

        public async Task<UpdateProductOptionResponse> UpdateProductOption(UpdateProductOptionCommand request)
        {
            var productOption = await ProductOptionRepository.Get(x => x.Id == request.Id && x.ProductId == request.ProductId);

            if (productOption is null || !productOption.Any())
            {
                return new()
                {
                    Errors = new()
                    {
                        new()
                        {
                            Code = "not_found",
                            Message = "Product Option not found",
                            Type = Seedwork.ResponseType.FAILURE
                        }
                    }
                };
            }

            await ProductOptionRepository.Update(Mapper.Map<ProductOptionEntity>(request));
            await UnitOfWork.Commit();

            return new();
        }

        public async Task<DeleteProductOptionResponse> DeleteProductOption(DeleteProductOptionCommand request)
        {
            var productOption = await ProductOptionRepository.Get(x => x.Id == request.Id && x.ProductId == request.ProductId);

            if (productOption is null || !productOption.Any())
            {
                return new()
                {
                    Errors = new()
                    {
                        new()
                        {
                            Code = "not_found",
                            Message = "Product option not found",
                            Type = Seedwork.ResponseType.FAILURE
                        }
                    }
                };
            }
            else
            {
                var productToUpdate = productOption.First();
                productToUpdate.IsActive = false;
                await ProductOptionRepository.Update(productToUpdate);
                await UnitOfWork.Commit();

            }

            return new();
        }
    }
}
