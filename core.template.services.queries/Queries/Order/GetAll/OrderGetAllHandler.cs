namespace core.template.services.queries.Queries.Order.GetAll
{
    using dataAccess;
    using MediatR;

    public class OrderGetAllHandler : IRequestHandler<OrderGetAllQuery, OrderGetAllResponse>
    {
        private readonly DemoContextReadOnly context;

        public OrderGetAllHandler()
        {
            this.context = new DemoContextReadOnly();
        }

        public OrderGetAllResponse Handle(OrderGetAllQuery message)
        {
            return new OrderGetAllResponse { Orders = this.context.Orders };
        }
    }
}
