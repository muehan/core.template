﻿namespace core.template.dataAccess
{
    using core.template.domain;
    using Microsoft.EntityFrameworkCore;

    public class DemoContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=65efd7f8-e33c-4e12-9b37-a7f000ec3b02.sqlserver.sequelizer.com;Database=db65efd7f8e33c4e129b37a7f000ec3b02;User ID=iookhqsevwmafwyf;Password=AyU2CeaCuLkFdXZWkd4aeiXCsWkAdoYoKfqkjUcoGdeNBmgbbNYi77hrHqHP2Gyg;MultipleActiveResultSets=True;");
        }
    }
}
