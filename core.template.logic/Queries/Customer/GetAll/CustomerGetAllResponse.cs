namespace core.template.logic.Queries.Customer.GetAll
{
    using System.Collections.Generic;
    using core.template.domain;

    public class CustomerGetAllResponse
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
}
