namespace core.template.services.commands.Configuration
{
    using AutoMapper;
    using Commands.Customer.Create;
    using Commands.Item.Create;
    using domain;

    public class MapperConfiguration
    {
        public void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CustomerCreateCommand, Customer>();
                cfg.CreateMap<ItemCreateCommand, Item>();
            });
        }
    }
}
