﻿using core.template.dataAccess;
using MediatR;
using System.Linq;

namespace core.template.logic.Queries.Customer.Query
{
    public class CustomerGetHandler : IRequestHandler<CustomerGetQuery, CustomerGetResponse>
    {
        private readonly DemoContextReadOnly context;

        public CustomerGetHandler()
        {
            context = new DemoContextReadOnly();
        }

        public CustomerGetResponse Handle(CustomerGetQuery message)
        {
            var response = new CustomerGetResponse();

            var customers = context.Customers.Where(x => x.Number.ToString() == message.QueryText);

            if (customers.Any())
            {
                response.Customers = customers;
                return response;
            }

            customers = context.Customers.Where(x => x.Name == message.QueryText);

            if (customers.Any())
            {
                response.Customers = customers;
                return response;
            }

            customers = context.Customers.Where(x => x.PreName == message.QueryText);

            if (customers.Any())
            {
                response.Customers = customers;
                return response;
            }
            
            return response;
        }
    }
}
