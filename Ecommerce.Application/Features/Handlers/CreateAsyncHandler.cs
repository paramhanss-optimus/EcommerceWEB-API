using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.Features.Commands.GenricCommand;
using Ecommerce.Application.Features.Queries.GenericQuery;
using Ecommerce.Domain.Interface;
using MediatR;

namespace Ecommerce.Application.Features.Handlers
{
    public class CreateAsyncHandler<T> : IRequestHandler<CreateAsyncCommand<T>, bool > where T : class
    {
        private readonly IGenericRepo<T> _genericRepo;

        public CreateAsyncHandler(IGenericRepo<T> genericRepo)
        {
            _genericRepo = genericRepo;
        }

        public async Task<bool> Handle(CreateAsyncCommand<T> request, CancellationToken cancellationToken)
        {
            return await _genericRepo.CreateAsync(request.entity);
        }
    }

}


