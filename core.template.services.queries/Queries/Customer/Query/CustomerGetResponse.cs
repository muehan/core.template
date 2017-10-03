namespace core.template.services.queries.Queries.Customer.Query
{
    using System.Collections.Generic;
    using domain;

    public class CustomerGetResponse
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
}
