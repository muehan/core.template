namespace core.template.services.queries.Queries.Order.GetAll
{
    using System.Collections.Generic;
    using domain;

    public class OrderGetAllResponse
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}
