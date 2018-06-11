using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using core.template.domain;
using core.template.services.commands.Commands.Customer.Create;
using core.template.services.commands.Commands.Customer.Delete;
using core.template.services.commands.Commands.Customer.Edit;
using core.template.services.queries.Queries.Customer.GetAll;
using core.template.services.queries.Queries.Customer.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace core.template.client.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            var command = new CustomerGetAllQuery();
            var response = await mediator.Send(command);

            return response.Customers;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Customer>> Get(int id)
        {
            var command = new CustomerGetQuery();
            command.QueryText = id.ToString();

            var response = await mediator.Send(command);

            return response.Customers;
        }

        // POST api/values
        [HttpPost]
        public async Task<CustomerCreateResponse> Post([FromBody]CustomerCreateCommand customerCommand)
        {
            var response = await mediator.Send(customerCommand);

            return response;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<CustomerEditResponse> Put(Guid id, [FromBody]CustomerEditCommand customerCommand)
        {
            var response = await mediator.Send(customerCommand);

            return response;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<CustomerDeleteResponse> Delete(Guid id)
        {
            var command = new CustomerDeleteCommand();
            command.Id = id;

            var response = await mediator.Send(command);

            return response;
        }
    }
}
