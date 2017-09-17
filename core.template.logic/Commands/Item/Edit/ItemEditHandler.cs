namespace core.template.logic.Commands.Item.Edit
{
    using core.template.dataAccess;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class ItemEditHandler : IRequestHandler<ItemEditCommand, ItemEditResponse>
    {
        private readonly DemoContext context;

        public ItemEditHandler()
        {
            context = new DemoContext();
        }

        public ItemEditResponse Handle(ItemEditCommand message)
        {
            var response = new ItemEditResponse();

            try
            {
                var item = context.Items.Find(message.Guid);
                item.Name = message.Item.Name;
                item.Number = message.Item.Number;
                item.Price = message.Item.Price;
                item.VenderNumber = message.Item.VenderNumber;
                response.Item = item;

                context.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                // logger here
            }

            return response;
        }
    }
}
