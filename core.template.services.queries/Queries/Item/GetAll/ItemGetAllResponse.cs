namespace core.template.services.queries.Queries.Item.GetAll
{
    using System.Collections.Generic;
    using domain;

    public class ItemGetAllResponse
    {
        public IEnumerable<Item> Items { get; set; }
    }
}
