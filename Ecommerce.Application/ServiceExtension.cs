using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Ecommerce.Application.Features.Queries.GenericQuery;
using Ecommerce.Domain.Entities;
using Ecommerce.Application.Features.Handlers;
using System.Reflection;
using Ecommerce.Application.Features.Commands.GenricCommand;

namespace Ecommerce.Application
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceExtension).Assembly));

            services.AddTransient(typeof(IRequestHandler<GetAllAsyncQuery<CustomerEntity>,IEnumerable<CustomerEntity>>), typeof(GetallAsyncHandler<CustomerEntity>));
            services.AddTransient(typeof(IRequestHandler<CreateAsyncCommand<CustomerEntity>,bool>), typeof(CreateAsyncHandler<CustomerEntity>));
            services.AddTransient(typeof(IRequestHandler<DeleteAsyncCommand<CustomerEntity>,bool>), typeof(DeleteAsyncHandler<CustomerEntity>));
            services.AddTransient(typeof(IRequestHandler<UpdateAsyncCommand<CustomerEntity>,bool>), typeof(UpdateAsyncHandler<CustomerEntity>));

            return services;
        }
    }
}