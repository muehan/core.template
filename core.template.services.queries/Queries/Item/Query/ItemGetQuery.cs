namespace core.template.services.queries.Queries.Item.Query
{
    using System;
    using MediatR;

    public class ItemGetQuery : IRequest<ItemGetResponse>
    {
        public Guid? Guid { get; set; }

        public string QueryText { get; set; }
    }
}
