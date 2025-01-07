using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Features.Commands.GenricCommand
{
    public record CreateAsyncCommand<T>(T entity) : IRequest<bool>;

}
