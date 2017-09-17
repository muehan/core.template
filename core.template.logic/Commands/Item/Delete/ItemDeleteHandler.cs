using core.template.dataAccess;
using core.template.logic.Helper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace core.template.logic.Commands.Item.Delete
{
    public class ItemDeleteHandler : IRequestHandler<ItemDeleteCommand, ItemDeleteResponse>
    {
        private readonly DemoContext context;

        public ItemDeleteHandler()
        {
            context = new DemoContext();
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

                context.Items.Remove(item);
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
