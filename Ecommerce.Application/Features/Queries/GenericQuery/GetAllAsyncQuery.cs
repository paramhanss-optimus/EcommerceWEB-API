using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ecommerce.Application.Features.Queries.GenericQuery
{
    public record GetAllAsyncQuery<T>() : IRequest<IEnumerable<T>>;

}
