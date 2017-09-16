namespace core.template.domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        [Key]
        public Guid Guid { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public string PreName { get; set; }

        public string PhoneNumber { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public int ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
