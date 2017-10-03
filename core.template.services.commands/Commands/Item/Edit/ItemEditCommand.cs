namespace core.template.services.commands.Commands.Item.Edit
{
    using System;
    using domain;
    using MediatR;

    public class ItemEditCommand : IRequest<ItemEditResponse>
    {
        public Guid Guid { get; set; }

        public Item Item { get; set; }
    }
}
