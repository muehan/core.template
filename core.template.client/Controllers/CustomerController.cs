namespace core.template.api.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using MediatR;
    using System.Threading.Tasks;
    using domain;
    using System;
    using services.commands.Commands.Customer.Create;
    using services.commands.Commands.Customer.Delete;
    using services.commands.Commands.Customer.Edit;
    using services.queries.Queries.Customer.GetAll;
    using services.queries.Queries.Customer.Query;

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
