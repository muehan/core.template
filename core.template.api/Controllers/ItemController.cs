using core.template.domain;
using core.template.logic.Commands.Item.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace core.template.api.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private IMediator mediator;

        public ItemController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Item>> Get()
        {
            //var command = new CustomerGetAllQuery();
            //var response = await mediator.Send(command);

            //return response.Customers;
            return null;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Item>> Get(int id)
        {
            //var command = new CustomerGetQuery();
            //command.QueryText = id.ToString();

            //var response = await mediator.Send(command);

            //return response.Customers;
            return null;
        }

        // POST api/values
        [HttpPost]
        public async Task<ItemCreateResponse> Post([FromBody]ItemCreateCommand itemCommand)
        {
            var response = await mediator.Send(itemCommand);

            return response;
        }

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public async Task<logic.Commands.Customer.Edit.CustomerEditResponse> Put(int id, [FromBody]CustomerEditCommand customerCommand)
        //{
        //    var response = await mediator.Send(customerCommand);

        //    return response;
        //}

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public async Task<CustomerDeleteResponse> Delete(int id)
        //{
        //    var command = new CustomerDeleteCommand();
        //    command.Id = id;

        //    var response = await mediator.Send(command);

        //    return response;
        //}
    }
}