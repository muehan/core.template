namespace core.template.services.queries.Queries.Item.Query
{
    using System.Linq;
    using dataAccess;
    using MediatR;

    public class ItemGetHandler : IRequestHandler<ItemGetQuery, ItemGetResponse>
    {
        private readonly DemoContextReadOnly context;

        public ItemGetHandler(DemoContextReadOnly context)
        {
            this.context = context;
        }

        public ItemGetResponse Handle(ItemGetQuery message)
        {
            var response = new ItemGetResponse();

            if (message.Guid != null)
            {
                response.Items = new[] { this.context.Items.Find(message.Guid) };
            }
            else
            {
                response.Items = this.context.Items.Where(x => x.Name.Contains(message.QueryText));
                response.Items.ToList().AddRange(this.context.Items.Where(x => x.Number.ToString().Contains(message.QueryText)));
                response.Items.ToList().AddRange(this.context.Items.Where(x => x.VenderNumber.ToString().Contains(message.QueryText)));
            }

            return response;
        }
    }
}
