using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hexa.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProductPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "ProductPicture",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2024, 2, 24, 22, 10, 57, 193, DateTimeKind.Local).AddTicks(8444));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "ProductPicture");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2024, 2, 24, 16, 13, 3, 379, DateTimeKind.Local).AddTicks(8574));
        }
    }
}
