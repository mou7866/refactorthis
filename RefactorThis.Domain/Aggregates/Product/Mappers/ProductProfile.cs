using AutoMapper;
using RefactorThis.Data.Models;
using RefactorThis.Domain.Aggregates.Product.Commands;

namespace RefactorThis.Domain.Aggregates.Product.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            MapCreateProduct();
        }

        private void MapCreateProduct()
        {
            CreateMap<CreateProductCommand, ProductEntity>()
                .ForMember(dest => dest.Id, src => src.Ignore());
        }
    }
}