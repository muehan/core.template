namespace core.template.logic.Commands.Customer.Edit
{
    using MediatR;
    using core.template.domain;

    public class CustomerEditCommand : IRequest<CustomerEditResponse>
    {
        public int Guid { get; set; }

        public Customer Customer { get; set; }
    }
}
