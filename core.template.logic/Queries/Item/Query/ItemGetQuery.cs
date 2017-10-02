using MediatR;

namespace core.template.logic.Queries.Item.Query
{
    using System;

    public class ItemGetQuery : IRequest<ItemGetResponse>
    {
        public Guid? Guid { get; set; }

        public string QueryText { get; set; }
    }
}
