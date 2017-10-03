namespace core.template.services.commands.Commands.Customer.Delete
{
    using System;
    using MediatR;

    public class CustomerDeleteCommand : IRequest<CustomerDeleteResponse>
    {
        public Guid Id { get; set; }
    }
}
