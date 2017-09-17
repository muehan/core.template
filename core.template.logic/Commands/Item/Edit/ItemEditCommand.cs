namespace core.template.logic.Commands.Item.Edit
{
    using MediatR;
    using core.template.domain;
    using System;

    public class ItemEditCommand : IRequest<ItemEditResponse>
    {
        public Guid Guid { get; set; }

        public Item Item { get; set; }
    }
}
