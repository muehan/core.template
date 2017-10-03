namespace core.template.services.queries.Queries.Customer.GetAll
{
    using System.Collections.Generic;
    using domain;

    public class CustomerGetAllResponse
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
}
