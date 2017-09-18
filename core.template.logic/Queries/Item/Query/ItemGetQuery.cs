using MediatR;

namespace core.template.logic.Queries.Item.Query
{
    public class ItemGetQuery : IRequest<ItemGetResponse>
    {
        public string QueryText { get; set; }
    }
}
