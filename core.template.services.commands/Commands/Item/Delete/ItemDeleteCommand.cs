namespace core.template.services.commands.Commands.Item.Delete
{
    using MediatR;

    public class ItemDeleteCommand : IRequest<ItemDeleteResponse>
    {
        public int Id { get; set; }
    }
}
