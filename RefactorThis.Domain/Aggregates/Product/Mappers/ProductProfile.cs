using AutoMapper;
using RefactorThis.Data.Models;
using RefactorThis.Domain.Aggregates.Product.Commands;
using RefactorThis.Domain.Product.Models;

namespace RefactorThis.Domain.Aggregates.Product.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            MapCreateProduct();
            MapGetAllProducts();
            MapUpdateProduct();
            MapDeleteProduct();

            MapGetAllProductOptions();
            MapCreateProductOption();
            MapUpdateProductOption();
        }

        public void MapCreateProduct()
        {
            CreateMap<CreateProductCommand, ProductEntity>()
                .ForMember(dest => dest.Id, src => src.Ignore())
                .ForMember(dest => dest.IsActive, src => src.MapFrom(x => true));
        }

        public void MapGetAllProducts()
        {
            CreateMap<ProductEntity, ProductModel>();
        }

        public void MapUpdateProduct()
        {
            CreateMap<UpdateProductCommand, ProductEntity>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.DeliveryPrice, src => src.MapFrom(x => x.Product.DeliveryPrice))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Product.Description))
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Product.Name))
                .ForMember(dest => dest.Price, src => src.MapFrom(x => x.Product.Price));
        }

        public void MapDeleteProduct()
        {
            CreateMap<DeleteProductCommand, ProductEntity>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.IsActive, src => src.MapFrom(x => false));
        }

        public void MapGetAllProductOptions()
        {
            CreateMap<ProductOptionEntity, ProductOptionModel>();
        }

        public void MapCreateProductOption()
        {
            CreateMap<CreateProductOptionCommand, ProductOptionEntity>()
                .ForMember(dest => dest.Id, src => src.Ignore())
                .ForMember(dest => dest.IsActive, src => src.MapFrom(x => true))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Option.Description))
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Option.Name))
                .ForMember(dest => dest.ProductId, src => src.MapFrom(x => x.ProductId));
        }

        public void MapUpdateProductOption()
        {
            CreateMap<UpdateProductOptionCommand, ProductOptionEntity>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Option.Description))
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Option.Name))
                .ForMember(dest => dest.IsActive, src => src.MapFrom(x => true))
                .ForMember(dest => dest.ProductId, src => src.MapFrom(x => x.ProductId));
        }
    }
}