namespace core.template.services.queries.Queries.Customer.Query
{
    using System.Linq;
    using dataAccess;
    using MediatR;

    public class CustomerGetHandler : IRequestHandler<CustomerGetQuery, CustomerGetResponse>
    {
        private readonly DemoContextReadOnly context;

        public CustomerGetHandler(DemoContextReadOnly context)
        {
            this.context = context;
        }

        public CustomerGetResponse Handle(CustomerGetQuery message)
        {
            var response = new CustomerGetResponse();

            response.Customers = this.context.Customers.Where(x => x.Number.ToString() == message.QueryText);
            response.Customers.ToList().AddRange(this.context.Customers.Where(x => x.Name == message.QueryText));
            response.Customers.ToList().AddRange(this.context.Customers.Where(x => x.PreName == message.QueryText));
            
            return response;
        }
    }
}
