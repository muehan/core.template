namespace core.template.services.commands.Commands.Customer.Create
{
    using System;
    using AutoMapper;
    using dataAccess;
    using domain;
    using MediatR;

    public class CustomerCreateHandler : IRequestHandler<CustomerCreateCommand, CustomerCreateResponse>
    {
        private readonly DemoContext context;

        public CustomerCreateHandler()
        {
            this.context = new DemoContext();
        }

        public CustomerCreateResponse Handle(CustomerCreateCommand message)
        {
            var customer = Mapper.Map<Customer>(message);
            customer.Guid = Guid.NewGuid();
            Customer newCustomer = null;

            try { 
                newCustomer = this.context.Customers.Add(customer).Entity;
                this.context.SaveChanges();
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
