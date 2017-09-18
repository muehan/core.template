namespace core.template.logic.Queries.Order.GetAll
{
    using core.template.dataAccess;
    using MediatR;
    using System;

    public class OrderGetAllHandler : IRequestHandler<OrderGetAllQuery, OrderGetAllResponse>
    {
        private readonly DemoContextReadOnly context;

        public OrderGetAllHandler()
        {
            context = new DemoContextReadOnly();
        }

        public OrderGetAllResponse Handle(OrderGetAllQuery message)
        {
            return new OrderGetAllResponse { Orders = context.Orders };
        }
    }
}
