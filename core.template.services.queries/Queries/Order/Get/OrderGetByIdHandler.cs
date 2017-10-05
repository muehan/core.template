
namespace core.template.services.queries.Queries.Order.Get
{
    using dataAccess;
    using MediatR;

    public class OrderGetByIdHandler : IRequestHandler<OrderGetByIdQuery, OrderGetByIdResponse>
    {
        private readonly DemoContextReadOnly context;

        public OrderGetByIdHandler(DemoContextReadOnly context)
        {
            this.context = context;
        }

        public OrderGetByIdResponse Handle(OrderGetByIdQuery message)
        {
            return new OrderGetByIdResponse { Order = this.context.Orders.Find(message.Id) };
        }
    }
}
