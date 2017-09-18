namespace core.template.logic.Commands.Order.Create
{
    using MediatR;
    using core.template.domain;

    public class OrderCreateCommand : IRequest<OrderCreateResponse>
    {
        public Order Order { get; set; }
    }
}
