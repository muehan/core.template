namespace core.template.services.queries.Queries.Item.Query
{
    using System.Collections.Generic;
    using domain;

    public class ItemGetResponse
    {
        public IEnumerable<Item> Items { get; set; }
    }
}
