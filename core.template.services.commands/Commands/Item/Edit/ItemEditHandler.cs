namespace core.template.services.commands.Commands.Item.Edit
{
    using dataAccess;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class ItemEditHandler : IRequestHandler<ItemEditCommand, ItemEditResponse>
    {
        private readonly DemoContext context;

        public ItemEditHandler(DemoContext context)
        {
            this.context = context;
        }

        public ItemEditResponse Handle(ItemEditCommand message)
        {
            var response = new ItemEditResponse();

            try
            {
                var item = this.context.Items.Find(message.Guid);
                item.Name = message.Item.Name;
                item.Number = message.Item.Number;
                item.Price = message.Item.Price;
                item.VenderNumber = message.Item.VenderNumber;
                response.Item = item;

                this.context.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                // logger here
            }

            return response;
        }
    }
}
