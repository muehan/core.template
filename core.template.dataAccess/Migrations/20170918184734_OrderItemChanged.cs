using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace core.template.dataAccess.Migrations
{
    public partial class OrderItemChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderItems_OrderItemGuid",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderItemGuid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderItemGuid",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "OrderItems");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderItemGuid",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderItemGuid",
                table: "Orders",
                column: "OrderItemGuid",
                unique: true,
                filter: "[OrderItemGuid] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderItems_OrderItemGuid",
                table: "Orders",
                column: "OrderItemGuid",
                principalTable: "OrderItems",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
