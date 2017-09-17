namespace core.template.logic.Commands.Item.Delete
{
    using MediatR;

    public class ItemDeleteCommand : IRequest<ItemDeleteResponse>
    {
        public int Id { get; set; }
    }
}
