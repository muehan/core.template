namespace core.template.logic.Queries.Customer.Query
{
    using System.Collections.Generic;
    using core.template.domain;

    public class CustomerGetResponse
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
}
