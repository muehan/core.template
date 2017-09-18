using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace core.template.dataAccess.Migrations
{
    public partial class OrderItemRenaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Items_ItemGuid",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderItem_OrderItemGuid",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "OrderItems");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_ItemGuid",
                table: "OrderItems",
                newName: "IX_OrderItems_ItemGuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Items_ItemGuid",
                table: "OrderItems",
                column: "ItemGuid",
                principalTable: "Items",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderItems_OrderItemGuid",
                table: "Orders",
                column: "OrderItemGuid",
                principalTable: "OrderItems",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Items_ItemGuid",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderItems_OrderItemGuid",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderItem");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ItemGuid",
                table: "OrderItem",
                newName: "IX_OrderItem_ItemGuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Items_ItemGuid",
                table: "OrderItem",
                column: "ItemGuid",
                principalTable: "Items",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderItem_OrderItemGuid",
                table: "Orders",
                column: "OrderItemGuid",
                principalTable: "OrderItem",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
