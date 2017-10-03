namespace core.template.services.commands.Commands.Order.Create
{
    using domain;
    using MediatR;

    public class OrderCreateCommand : IRequest<OrderCreateResponse>
    {
        public Order Order { get; set; }
    }
}
