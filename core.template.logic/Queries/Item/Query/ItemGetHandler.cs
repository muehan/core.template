namespace core.template.logic.Queries.Item.Query
{
    using core.template.dataAccess;
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;

    public class ItemGetHandler : IRequestHandler<ItemGetQuery, ItemGetResponse>
    {
        private readonly DemoContextReadOnly context;

        public ItemGetHandler()
        {
            context = new DemoContextReadOnly();
        }

        public ItemGetResponse Handle(ItemGetQuery message)
        {
            var response = new ItemGetResponse();

            response.Items = context.Items.Where(x => x.Name.Contains(message.QueryText));
            response.Items.ToList().AddRange(context.Items.Where(x => x.Number.ToString().Contains(message.QueryText)));
            response.Items.ToList().AddRange(context.Items.Where(x => x.VenderNumber.ToString().Contains(message.QueryText)));

            return response;
        }
    }
}
