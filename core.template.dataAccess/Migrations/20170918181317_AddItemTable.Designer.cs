﻿// <auto-generated />
using core.template.dataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace core.template.dataAccess.Migrations
{
    [DbContext(typeof(DemoContext))]
    [Migration("20170918181317_AddItemTable")]
    partial class AddItemTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("core.template.domain.Customer", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Name");

                    b.Property<int>("Number");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PreName");

                    b.Property<string>("Street");

                    b.Property<string>("StreetNumber");

                    b.Property<int>("ZipCode");

                    b.HasKey("Guid");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("core.template.domain.Item", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Number");

                    b.Property<double>("Price");

                    b.Property<string>("VenderNumber");

                    b.HasKey("Guid");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("core.template.domain.Order", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<Guid?>("CustomerGuid");

                    b.Property<DateTime>("EstimatedDeliveryDate");

                    b.Property<int>("Number");

                    b.HasKey("Guid");

                    b.HasIndex("CustomerGuid");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("core.template.domain.Order", b =>
                {
                    b.HasOne("core.template.domain.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerGuid");
                });
#pragma warning restore 612, 618
        }
    }
}
