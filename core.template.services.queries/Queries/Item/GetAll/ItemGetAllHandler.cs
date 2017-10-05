namespace core.template.services.queries.Queries.Item.GetAll
{
    using dataAccess;
    using MediatR;

    public class ItemGetAllHandler : IRequestHandler<ItemGetAllQuery, ItemGetAllResponse>
    {
        private readonly DemoContextReadOnly context;

        public ItemGetAllHandler(DemoContextReadOnly context)
        {
            this.context = context;
        }

        public ItemGetAllResponse Handle(ItemGetAllQuery message)
        {
            var response = new ItemGetAllResponse();

            response.Items = this.context.Items;

            return response;
        }
    }
}
