namespace core.template.logic.Commands.Customer.Delete
{
    using MediatR;

    public class CustomerDeleteCommand : IRequest<CustomerDeleteResponse>
    {
        public int Id { get; set; }
    }
}
