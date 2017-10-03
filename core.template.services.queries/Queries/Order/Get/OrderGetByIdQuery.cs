namespace core.template.services.queries.Queries.Order.Get
{
    using System;
    using MediatR;

    public class OrderGetByIdQuery : IRequest<OrderGetByIdResponse>
    {
        public Guid Id { get; set; }
    }
}
