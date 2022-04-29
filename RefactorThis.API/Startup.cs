using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RefactorThis.Data;
using RefactorThis.Data.Repositories;
using RefactorThis.Domain.Aggregates.Product.Mappers;
using RefactorThis.Domain.Aggregates.Product.Services;
using RefactorThis.Domain.Seedwork;
using RefactorThis.Infrastructure.Repositories;
using System;
using System.Collections.Generic;

namespace RefactorThis.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RefactorThis.API", Version = "v1" });
            });

            var domainAssembly = AppDomain.CurrentDomain.Load("RefactorThis.Domain");

            services.AddMediatR(domainAssembly);
            services.AddValidatorsFromAssembly(domainAssembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient<IProductService, ProductService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfiles(new List<Profile>
                {
                    new ProductProfile()
                });
            });

            services.AddSingleton(mappingConfig.CreateMapper());

            services
                .AddDbContext<RefactorThisDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .EnableSensitiveDataLogging());

            services.AddTransient<IUnitOfWork, UnitOfWork<RefactorThisDbContext>>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductOptionRepository, ProductOptionRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RefactorThis.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
