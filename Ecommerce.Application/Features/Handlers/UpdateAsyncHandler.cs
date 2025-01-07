using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.Features.Commands.GenricCommand;
using Ecommerce.Domain.Interface;
using MediatR;

namespace Ecommerce.Application.Features.Handlers
{
    public class UpdateAsyncHandler<T>(IGenericRepo<T> genericRepo) : IRequestHandler<UpdateAsyncCommand<T>, bool> where T : class
    {
        public async Task<bool> Handle(UpdateAsyncCommand<T> request, CancellationToken cancellationToken)
        {
            return await genericRepo.UpdateAsync(request.entity);
        }
    }
}
