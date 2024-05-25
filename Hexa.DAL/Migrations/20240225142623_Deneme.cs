using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hexa.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Deneme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2024, 2, 25, 17, 26, 22, 857, DateTimeKind.Local).AddTicks(1484));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2024, 2, 25, 1, 46, 11, 820, DateTimeKind.Local).AddTicks(7853));
        }
    }
}
