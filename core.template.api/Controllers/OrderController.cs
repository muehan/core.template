namespace core.template.api.Controllers
{
    using core.template.domain;
    using core.template.logic.Queries.Order.Get;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using MediatR;
    using System.Collections.Generic;
    using core.template.logic.Queries.Order.GetAll;

    [Produces("application/json")]
    [Route("api/Order")]
    public class OrderController : Controller
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<Order> Get(Guid id)
        {
            var query = new OrderGetByIdQuery();
            query.Id = id;

            var response = await mediator.Send(query);

            return response.Order;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            var query = new OrderGetAllQuery();

            var response = await mediator.Send(query);

            return response.Orders;
        }

    }
}