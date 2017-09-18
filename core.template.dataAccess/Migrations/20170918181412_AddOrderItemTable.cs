using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace core.template.dataAccess.Migrations
{
    public partial class AddOrderItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderItemGuid",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_OrderItem_Items_ItemGuid",
                        column: x => x.ItemGuid,
                        principalTable: "Items",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderItemGuid",
                table: "Orders",
                column: "OrderItemGuid",
                unique: true,
                filter: "[OrderItemGuid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ItemGuid",
                table: "OrderItem",
                column: "ItemGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderItem_OrderItemGuid",
                table: "Orders",
                column: "OrderItemGuid",
                principalTable: "OrderItem",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderItem_OrderItemGuid",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderItemGuid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderItemGuid",
                table: "Orders");
        }
    }
}
