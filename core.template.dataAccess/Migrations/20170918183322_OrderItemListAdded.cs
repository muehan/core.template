using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace core.template.dataAccess.Migrations
{
    public partial class OrderItemListAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderGuid",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderGuid",
                table: "Items",
                column: "OrderGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Orders_OrderGuid",
                table: "Items",
                column: "OrderGuid",
                principalTable: "Orders",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Orders_OrderGuid",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_OrderGuid",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OrderGuid",
                table: "Items");
        }
    }
}
