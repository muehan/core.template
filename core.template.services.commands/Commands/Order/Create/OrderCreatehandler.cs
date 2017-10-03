namespace core.template.services.commands.Commands.Order.Create
{
    using System;
    using System.Linq;
    using dataAccess;
    using MediatR;

    public class OrderCreateHandler : IRequestHandler<OrderCreateCommand, OrderCreateResponse>
    {
        private readonly DemoContext context;
        private Object lockObject = new Object();

        public OrderCreateHandler()
        {
            this.context = new DemoContext();
        }

        public OrderCreateResponse Handle(OrderCreateCommand message)
        {
            var response = new OrderCreateResponse();
            var order = message.Order;
            order.Guid = Guid.NewGuid();

            lock (this.lockObject) { 
                order.Number = this.context.Orders.Max(x => x.Number) + 1;
            }

            order.Items.ForEach(item =>
            {                
                item.Guid = Guid.NewGuid();
                this.context.OrderItems.Add(item);
            });

            this.context.Orders.Add(order);
            this.context.SaveChanges();

            response.Order = order;
            return response;
        }
    }
}
