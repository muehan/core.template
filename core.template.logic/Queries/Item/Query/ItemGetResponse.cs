namespace core.template.logic.Queries.Item.Query
{
    using System.Collections.Generic;
    using core.template.domain;

    public class ItemGetResponse
    {
        public IEnumerable<Item> Items { get; set; }
    }
}
