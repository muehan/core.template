namespace core.template.services.commands.Commands.Item.Create
{
    using System;
    using AutoMapper;
    using dataAccess;
    using domain;
    using MediatR;

    public class ItemCreateHandler : IRequestHandler<ItemCreateCommand, ItemCreateResponse>
    {
        private readonly DemoContext context;

        public ItemCreateHandler(DemoContext context)
        {
            this.context = context;
        }

        public ItemCreateResponse Handle(ItemCreateCommand message)
        {
            var item = Mapper.Map<Item>(message);
            item.Guid = Guid.NewGuid();
            Item newItem = null;

            try {
                newItem = this.context.Items.Add(item).Entity;
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                // logger here
            }
            
            var response = new ItemCreateResponse();
            response.Item = newItem;

            return response;
        }
    }
}
