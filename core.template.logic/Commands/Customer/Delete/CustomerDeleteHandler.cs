namespace core.template.logic.Commands.Customer.Delete
{
    using core.template.dataAccess;
    using core.template.logic.Helper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class CustomerDeleteHandler : IRequestHandler<CustomerDeleteCommand, CustomerDeleteResponse>
    {
        private readonly DemoContext context;

        public CustomerDeleteHandler()
        {
            context = new DemoContext();
        }

        public CustomerDeleteResponse Handle(CustomerDeleteCommand message)
        {
            var customer = context.Customers.Find(message.Id);
            var response = new CustomerDeleteResponse();

            try
            {
                context.Customers.Remove(customer);
                context.SaveChanges();
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
