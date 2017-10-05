namespace core.template.services.queries.Queries.Order.GetAll
{
    using dataAccess;
    using MediatR;

    public class OrderGetAllHandler : IRequestHandler<OrderGetAllQuery, OrderGetAllResponse>
    {
        private readonly DemoContextReadOnly context;

        public OrderGetAllHandler(DemoContextReadOnly context)
        {
            this.context = context;
        }

        public OrderGetAllResponse Handle(OrderGetAllQuery message)
        {
            return new OrderGetAllResponse { Orders = this.context.Orders };
        }
    }
}
