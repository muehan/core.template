namespace core.template.logic.Queries.Order.GetAll
{
    using System.Collections.Generic;
    using core.template.domain;

    public class OrderGetAllResponse
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}
