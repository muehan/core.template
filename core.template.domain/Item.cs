using System;
using System.ComponentModel.DataAnnotations;

namespace core.template.domain
{
    public class Item
    {
        [Key]
        public Guid Guid { get; set; }

        public int Number { get; set; }

        public string VenderNumber { get; set; }

        public double Price { get; set; }

        public string Name { get; set; }
    }
}