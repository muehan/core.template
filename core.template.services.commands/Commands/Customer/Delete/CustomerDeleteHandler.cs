namespace core.template.services.commands.Commands.Customer.Delete
{
    using dataAccess;
    using infrastructure;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class CustomerDeleteHandler : IRequestHandler<CustomerDeleteCommand, CustomerDeleteResponse>
    {
        private readonly DemoContext context;

        public CustomerDeleteHandler()
        {
            this.context = new DemoContext();
        }

        public CustomerDeleteResponse Handle(CustomerDeleteCommand message)
        {
            var customer = this.context.Customers.Find(message.Id);
            var response = new CustomerDeleteResponse();

            try
            {
                this.context.Customers.Remove(customer);
                this.context.SaveChanges();
                response.Message = ResponseMessage.Deleted;
            }
            catch (DbUpdateException ex)
            {
                // add logger here
                response.Message = ResponseMessage.Error;
            }
            
            return response;
        }
    }
}
