using MediatR;

namespace core.template.logic.Queries.Customer.Query
{
    public class CustomerGetQuery : IRequest<CustomerGetResponse>
    {
        public string QueryText { get; set; }

    }
}
