namespace core.template.services.commands.Commands.Customer.Edit
{
    using System;
    using dataAccess;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class CustomerEditHandler : IRequestHandler<CustomerEditCommand, CustomerEditResponse>
    {
        private readonly DemoContext context;

        public CustomerEditHandler(DemoContext context)
        {
            this.context = context;
        }

        public CustomerEditResponse Handle(CustomerEditCommand message)
        {
            var response = new CustomerEditResponse();
            var oldCustomer = this.context.Customers.Find(message.Guid);

            if(oldCustomer == null)
            {
                throw new ArgumentException("customer not found");
            }

            try
            {
                oldCustomer.Country = message.Customer.Country;
                oldCustomer.City = message.Customer.City;
                oldCustomer.Name = message.Customer.Name;
                oldCustomer.Number = message.Customer.Number;
                oldCustomer.PhoneNumber = message.Customer.PhoneNumber;
                oldCustomer.PreName = message.Customer.PreName;
                oldCustomer.Street = message.Customer.Street;
                oldCustomer.StreetNumber = message.Customer.StreetNumber;
                oldCustomer.ZipCode = message.Customer.ZipCode;
                this.context.SaveChanges();
                response.Customer = oldCustomer;

            }
            catch (DbUpdateException ex)
            {
                // logger here
                return response;
            }

            return response;
        }
    }
}
