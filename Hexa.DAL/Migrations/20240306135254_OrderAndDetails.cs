﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hexa.DAL.Migrations
{
    /// <inheritdoc />
    public partial class OrderAndDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: true),
                    PaymentOption = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    RecDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    Distinct = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "Varchar(10)", maxLength: 10, nullable: true),
                    Phone = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: true),
                    MailAddress = table.Column<string>(type: "Varchar(80)", maxLength: 80, nullable: true),
                    NameSurname = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    ShipedFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: true),
                    ProductPicture = table.Column<string>(type: "Varchar(150)", maxLength: 150, nullable: true),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2024, 3, 6, 16, 52, 53, 884, DateTimeKind.Local).AddTicks(2852));

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderID",
                table: "OrderDetail",
                column: "OrderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2024, 2, 25, 17, 26, 22, 857, DateTimeKind.Local).AddTicks(1484));
        }
    }
}
