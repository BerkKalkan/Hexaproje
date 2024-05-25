using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hexa.DAL.Migrations
{
	/// <inheritdoc />
	public partial class Category : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Category",
				columns: table => new
				{
					ID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
					DisplayIndex = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Category", x => x.ID);
				});

			migrationBuilder.UpdateData(
				table: "Admin",
				keyColumn: "ID",
				keyValue: 1,
				column: "LastLoginDate",
				value: new DateTime(2023, 12, 15, 18, 28, 9, 414, DateTimeKind.Local).AddTicks(7094));
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Category");

			migrationBuilder.UpdateData(
				table: "Admin",
				keyColumn: "ID",
				keyValue: 1,
				column: "LastLoginDate",
				value: new DateTime(2023, 12, 8, 19, 1, 46, 896, DateTimeKind.Local).AddTicks(8248));
		}
	}
}
