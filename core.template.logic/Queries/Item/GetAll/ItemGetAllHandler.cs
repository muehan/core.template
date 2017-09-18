using core.template.dataAccess;
using MediatR;

namespace core.template.logic.Queries.Item.GetAll
{
    public class ItemGetAllHandler : IRequestHandler<ItemGetAllQuery, ItemGetAllResponse>
    {
        private readonly DemoContextReadOnly context;

        public ItemGetAllHandler()
        {
            context = new DemoContextReadOnly();
        }

        public ItemGetAllResponse Handle(ItemGetAllQuery message)
        {
            var response = new ItemGetAllResponse();

            response.Items = context.Items;

            return response;
        }
    }
}
