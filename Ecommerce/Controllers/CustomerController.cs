using AutoMapper;
using Azure.Core;
using Ecommerce.Application.Features.Commands.GenricCommand;
using Ecommerce.Application.Features.Handlers;
using Ecommerce.Application.Features.Queries.GenericQuery;
using Ecommerce.Application.Mapping;
using Ecommerce.Domain.DTO;
using Ecommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ISender _sender;

        public CustomerController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDTO cust, CancellationToken ct)
        {

            var mapper = CustomerMapping.InitialiseMapper();
            var custEntity = mapper.Map<CustomerEntity>(cust);
            var result = await _sender.Send(new CreateAsyncCommand<CustomerEntity>(custEntity), ct);
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCustomers(CancellationToken ct)
        {
            var result = await _sender.Send(new GetAllAsyncQuery<CustomerEntity>(), ct);
            return Ok(result);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerDTO cust, CancellationToken ct)
        {
            var mapper = CustomerMapping.InitialiseMapper();
            var custEntity = mapper.Map<CustomerEntity>(cust);
            var result = await _sender.Send(new UpdateAsyncCommand<CustomerEntity>(custEntity), ct);
            return Ok(result);
        }

        [HttpDelete("")]
        public async Task<IActionResult> DeleteCustomer([FromBody] int custid, CancellationToken ct)
        {
            //var mapper = CustomerMapping.InitialiseMapper();
            //var custEntity = mapper.Map<CustomerEntity>(cust);
            var result = await _sender.Send(new DeleteAsyncCommand<int>(custid), ct);
            return Ok(result);
        }
    }
}


