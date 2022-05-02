using AutoMapper;
using Microsoft.AspNetCore.Mvc.Testing;
using RefactorThis.API;
using RefactorThis.Data.Models;
using RefactorThis.Domain.Product.Models;
using System.Collections.Generic;
using Xunit;

namespace RefactorThis.Test.Domain.Aggregates.Product.Mappers
{
    public class ProductProfileTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly IMapper mapper;

        public ProductProfileTests(WebApplicationFactory<Startup> factory)
        {
            mapper = factory.Services.GetService(typeof(IMapper)) as IMapper;
        }

        [Fact]
        public void GetAllProducts_ReturnSuccessful ()
        {
            List<ProductEntity> productEntities = new()
            { 
                new ProductEntity()
                {
                    Id = System.Guid.NewGuid(),
                    DeliveryPrice = 1.00M,
                    Description = "test description",
                    Name = "test name",
                    IsActive = true,
                    Price = 1.00M
                }
            };
            var result = mapper.Map<List<ProductModel>>(productEntities);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
