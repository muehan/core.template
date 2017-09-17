namespace core.template.logic.Commands.Item.Create
{
    using MediatR;

    public class ItemCreateCommand : IRequest<ItemCreateResponse>
    {
        public int Number { get; set; }

        public string VenderNumber { get; set; }

        public double Price { get; set; }

        public string Name { get; set; }
    }
}