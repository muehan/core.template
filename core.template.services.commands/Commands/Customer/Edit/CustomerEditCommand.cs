namespace core.template.services.commands.Commands.Customer.Edit
{
    using domain;
    using MediatR;

    public class CustomerEditCommand : IRequest<CustomerEditResponse>
    {
        public int Guid { get; set; }

        public Customer Customer { get; set; }
    }
}
