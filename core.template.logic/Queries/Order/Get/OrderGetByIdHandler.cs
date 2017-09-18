
namespace core.template.logic.Queries.Order.Get
{
    using core.template.dataAccess;
    using MediatR;
    using System;

    public class OrderGetByIdHandler : IRequestHandler<OrderGetByIdQuery, OrderGetByIdResponse>
    {
        private readonly DemoContextReadOnly context;

        public OrderGetByIdHandler()
        {
            context = new DemoContextReadOnly();
        }

        public OrderGetByIdResponse Handle(OrderGetByIdQuery message)
        {
            return new OrderGetByIdResponse { Order = context.Orders.Find(message.Id) };
        }
    }
}
