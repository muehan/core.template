namespace core.template.logic.Commands.Customer.Create
{
    using AutoMapper;
    using core.template.dataAccess;
    using core.template.domain;
    using MediatR;
    using System;

    public class CustomerCreateHandler : IRequestHandler<CustomerCreateCommand, CustomerCreateResponse>
    {
        private readonly DemoContext context;

        public CustomerCreateHandler()
        {
            context = new DemoContext();
        }

        public CustomerCreateResponse Handle(CustomerCreateCommand message)
        {
            var customer = Mapper.Map<Customer>(message);
            customer.Guid = Guid.NewGuid();
            Customer newCustomer = null;

            try { 
                newCustomer = context.Customers.Add(customer).Entity;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                // logger here
            }
            
            var response = new CustomerCreateResponse();
            response.Customer = newCustomer;

            return response;
        }
    }
}
