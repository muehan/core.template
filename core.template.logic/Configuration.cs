namespace core.template.logic
{
    using AutoMapper;
    using core.template.domain;
    using core.template.logic.Commands.Customer.Create;

    public class Configuration
    {
        public void MapperConfiguration()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CustomerCreateCommand, Customer>();
                
            });
        }
    }
}
