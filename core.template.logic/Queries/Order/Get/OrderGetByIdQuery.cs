namespace core.template.logic.Queries.Order.Get
{
    using MediatR;
    using System;

    public class OrderGetByIdQuery : IRequest<OrderGetByIdResponse>
    {
        public Guid Id { get; set; }
    }
}
