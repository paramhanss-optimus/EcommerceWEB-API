using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Domain
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(CustomerMapper));

            return services;
        }
    }
}
