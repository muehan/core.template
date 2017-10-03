namespace core.template.services.queries.Queries.Customer.GetAll
{
    using dataAccess;
    using MediatR;

    public class CustomerGetAllHandler : IRequestHandler<CustomerGetAllQuery, CustomerGetAllResponse>
    {
        private readonly DemoContextReadOnly context;

        public CustomerGetAllHandler()
        {
            this.context = new DemoContextReadOnly();
        }

        public CustomerGetAllResponse Handle(CustomerGetAllQuery message)
        {
            var response = new CustomerGetAllResponse();
            response.Customers = this.context.Customers;

            return response;
        }
    }
}
