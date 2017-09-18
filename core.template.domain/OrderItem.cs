using System;
using System.ComponentModel.DataAnnotations;

namespace core.template.domain
{
    public class OrderItem
    {
        [Key]
        public Guid Guid { get; set; }

        public int Amount { get; set; }

        public Item Item { get; set; }
    }
}
