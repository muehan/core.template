namespace core.template.logic.Commands.Item.Create
{
    using AutoMapper;
    using core.template.dataAccess;
    using core.template.domain;
    using MediatR;
    using System;

    public class ItemCreateHandler : IRequestHandler<ItemCreateCommand, ItemCreateResponse>
    {
        private readonly DemoContext context;

        public ItemCreateHandler()
        {
            context = new DemoContext();
        }

        public ItemCreateResponse Handle(ItemCreateCommand message)
        {
            var item = Mapper.Map<Item>(message);
            item.Guid = Guid.NewGuid();
            Item newItem = null;

            try {
                newItem = context.Items.Add(item).Entity;
                context.SaveChanges();
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
