using GeekShopping.ProductAPI.Config;
using GeekShopping.ProductAPI.model.Context;
using GeekShopping.ProductAPI.Repository;
using GeekShopping.ProductAPI.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextDb>(options =>
                                             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddAutoMapper(typeof(MappingConfig));
            //service.AddScoped<IPersonService, PersonService>();

            return service;
        }
    }
}
