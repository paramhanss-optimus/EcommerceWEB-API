using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ecommerce.Application.Features.Commands.GenricCommand
{
    public record UpdateAsyncCommand<T>(T entity) : IRequest<bool>;

}
