namespace core.template.logic
{
    using AutoMapper;
    using core.template.domain;
    using core.template.logic.Commands.Customer.Create;
    using core.template.logic.Commands.Item.Create;

    public class Configuration
    {
        public void MapperConfiguration()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CustomerCreateCommand, Customer>();
                cfg.CreateMap<ItemCreateCommand, Item>();

            });
        }
    }
}
