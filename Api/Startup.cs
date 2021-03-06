using Domain.Catalog;
using Domain.Warehouse;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Api", Version = "v1"});
            });
            
            services.AddSingleton<CatalogService>();
            services.AddSingleton<InventoryService>();
            services.AddSingleton<Domain.Warehouse.IProductRepository, Infrastructure.Warehouse.ProductRepository>();
            services.AddSingleton<Domain.Catalog.IProductRepository, Infrastructure.Catalog.ProductRepository>();
            services.AddSingleton<DomainEventService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DomainEventService domainEventService, Domain.Catalog.IProductRepository productRepository)
        {
            domainEventService.AddHandler(new InventoryLevelChangedEventHandler(productRepository));
            
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}