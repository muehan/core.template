namespace core.template.logic.Commands.Order.Create
{
    using MediatR;
    using core.template.dataAccess;
    using System;
    using System.Linq;

    public class OrderCreateHandler : IRequestHandler<OrderCreateCommand, OrderCreateResponse>
    {
        private readonly DemoContext context;
        private Object lockObject = new Object();

        public OrderCreateHandler()
        {
            context = new DemoContext();
        }

        public OrderCreateResponse Handle(OrderCreateCommand message)
        {
            var response = new OrderCreateResponse();
            var order = message.Order;
            order.Guid = Guid.NewGuid();

            lock (lockObject) { 
                order.Number = context.Orders.Max(x => x.Number) + 1;
            }

            order.Items.ForEach(item =>
            {                
                item.Guid = Guid.NewGuid();
                context.OrderItems.Add(item);
            });

            context.Orders.Add(order);
            context.SaveChanges();

            response.Order = order;
            return response;
        }
    }
}
