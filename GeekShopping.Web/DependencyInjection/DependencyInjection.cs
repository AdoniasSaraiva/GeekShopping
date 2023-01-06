using GeekShopping.Web.Services;
using GeekShopping.Web.Services.IServices;
using Microsoft.Extensions.Configuration;

namespace GeekShopping.ProductAPI.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddHttpClient<IProductService, ProductService>(config =>
                config.BaseAddress = new Uri(configuration["ServiceUrls:ProductAPI"])
            );

            return service;
        }
    }
}
