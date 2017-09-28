namespace core.template.logic.Commands.Customer.Delete
{
    using MediatR;
    using System;

    public class CustomerDeleteCommand : IRequest<CustomerDeleteResponse>
    {
        public Guid Id { get; set; }
    }
}
