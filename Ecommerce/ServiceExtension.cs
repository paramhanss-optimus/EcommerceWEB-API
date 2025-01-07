using Ecommerce.Application;
using Ecommerce.Persistance.Services;

namespace Ecommerce
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddAPI(this IServiceCollection services)
        {

            services.AddApplication()
                .AddPersistence();


            return services;
        }
    }
}
