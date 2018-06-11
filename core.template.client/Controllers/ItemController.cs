using System;
using System.Threading.Tasks;
using core.template.services.commands.Commands.Item.Create;
using core.template.services.commands.Commands.Item.Delete;
using core.template.services.commands.Commands.Item.Edit;
using core.template.services.queries.Queries.Item.GetAll;
using core.template.services.queries.Queries.Item.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace core.template.client.Controllers
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
        public async Task<ItemGetAllResponse> Get()
        {
            var command = new ItemGetAllQuery();
            var response = await mediator.Send(command);
            
            return response;
        }

        // GET api/values/5
        [HttpGet("id")]
        public async Task<ItemGetResponse> Get(Guid id)
        {
            var response = await mediator.Send(new ItemGetQuery { Guid = id });
            
            return response;
        }

        // POST api/values
        [HttpPost]
        public async Task<ItemCreateResponse> Post([FromBody]ItemCreateCommand command)
        {
            var response = await mediator.Send(command);

            return response;
        }

        // PUT api/values/
        [HttpPut]
        public async Task<ItemEditResponse> Put([FromBody]ItemEditCommand command)
        {
            var response = await mediator.Send(command);

            return response;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ItemDeleteResponse> Delete(ItemDeleteCommand command)
        {
            var response = await mediator.Send(command);

            return response;
        }
    }
}