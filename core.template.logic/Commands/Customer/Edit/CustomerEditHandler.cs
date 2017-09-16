using MediatR;

namespace core.template.logic.Commands.Customer.Edit
{
    public class CustomerEditHandler : IRequestHandler<CustomerEditCommand, CustomerEditResponse>
    {
        public CustomerEditResponse Handle(CustomerEditCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}
