namespace core.template.services.queries.Queries.Customer.Query
{
    using MediatR;

    public class CustomerGetQuery : IRequest<CustomerGetResponse>
    {
        public string QueryText { get; set; }

    }
}
