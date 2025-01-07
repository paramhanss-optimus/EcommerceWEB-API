using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Interface;
using Ecommerce.Persistance.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Persistance.Services
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<EcomerceDBContext>(option => option.UseSqlServer("Server=CPC-param-7Q3RT;Database=EcommParam3DB;Trusted_Connection=True;TrustServerCertificate=true;")
            .UseLazyLoadingProxies());

            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepository<>));
            return services;
        }
    }
}


