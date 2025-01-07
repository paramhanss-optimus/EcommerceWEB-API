using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.Features.Queries.GenericQuery;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interface;
using MediatR;

namespace Ecommerce.Application.Features.Handlers
{
    public class GetallAsyncHandler<T> : IRequestHandler<GetAllAsyncQuery<T>, IEnumerable<T>> where T : class
    {
        private readonly IGenericRepo<T> _genericRepo;

        public GetallAsyncHandler(IGenericRepo<T> genericRepo)
        {
            _genericRepo = genericRepo;
        }

        public async Task<IEnumerable<T>> Handle(GetAllAsyncQuery<T> request, CancellationToken cancellationToken)
        {
            return await _genericRepo.GetAllAsync();
        }
    }
}





