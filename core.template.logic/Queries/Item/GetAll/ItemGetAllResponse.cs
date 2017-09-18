namespace core.template.logic.Queries.Item.GetAll
{
    using System.Collections.Generic;
    using core.template.domain;

    public class ItemGetAllResponse
    {
        public IEnumerable<Item> Items { get; set; }
    }
}
