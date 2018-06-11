using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using core.template.domain;
using core.template.services.queries.Queries.Order.Get;
using core.template.services.queries.Queries.Order.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace core.template.client.Controllers
{
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