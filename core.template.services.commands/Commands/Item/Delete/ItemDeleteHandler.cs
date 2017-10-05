namespace core.template.services.commands.Commands.Item.Delete
{
    using dataAccess;
    using infrastructure;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class ItemDeleteHandler : IRequestHandler<ItemDeleteCommand, ItemDeleteResponse>
    {
        private readonly DemoContext context;

        public ItemDeleteHandler(DemoContext context)
        {
            this.context = context;
        }

        public ItemDeleteResponse Handle(ItemDeleteCommand message)
        {
            var itemResponse = new ItemDeleteResponse();

            try
            {
                var item = this.context.Items.Find(message.Id);
                if(item == null)
                {
                    itemResponse.Message = ResponseMessage.NotFound;
                    return itemResponse;
                }

                this.context.Items.Remove(item);
                itemResponse.Message = ResponseMessage.Deleted;
            }
            catch (DbUpdateException ex)
            {
                // logger here
                itemResponse.Message = ResponseMessage.Error;
            }

            return itemResponse;
        }
    }
}
