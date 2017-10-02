using core.template.logic.Commands.Item.Create;
using core.template.logic.Commands.Item.Delete;
using core.template.logic.Commands.Item.Edit;
using core.template.logic.Queries.Item.GetAll;
using core.template.logic.Queries.Item.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ItemGetAllResponse> Get()
        {
            var command = new ItemGetAllQuery();
            var response = await mediator.Send(command);
            
            return response;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ItemGetResponse> Get(ItemGetQuery query)
        {
            var response = await mediator.Send(query);
            
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