namespace core.template.domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        [Key]
        public Guid Guid { get; set; }

        public int Number { get; set; }

        public DateTime Created { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        public Customer Customer { get; set; }

        public List<OrderItem> Items { get; set; }
    }
}
