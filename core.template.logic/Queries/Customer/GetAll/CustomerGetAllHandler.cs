using core.template.dataAccess;
using MediatR;

namespace core.template.logic.Queries.Customer.GetAll
{
    public class CustomerGetAllHandler : IRequestHandler<CustomerGetAllQuery, CustomerGetAllResponse>
    {
        private readonly DemoContextReadOnly context;

        public CustomerGetAllHandler()
        {
            context = new DemoContextReadOnly();
        }

        public CustomerGetAllResponse Handle(CustomerGetAllQuery message)
        {
            var response = new CustomerGetAllResponse();
            response.Customers = context.Customers;

            return response;
        }
    }
}
