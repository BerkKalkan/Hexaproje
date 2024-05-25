using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hexa.DAL.Migrations
{
	/// <inheritdoc />
	public partial class Initial : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Admin",
				columns: table => new
				{
					ID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UserName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
					Password = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
					NameSurname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
					LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					LastLoginIP = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Admin", x => x.ID);
				});

			migrationBuilder.CreateTable(
				name: "Slayt",
				columns: table => new
				{
					ID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Slogan = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
					Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
					Description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
					Picture = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
					Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Link = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
					DisplayIndex = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Slayt", x => x.ID);
				});

			migrationBuilder.InsertData(
				table: "Admin",
				columns: new[] { "ID", "LastLoginDate", "LastLoginIP", "NameSurname", "Password", "UserName" },
				values: new object[] { 1, new DateTime(2023, 12, 8, 19, 1, 46, 896, DateTimeKind.Local).AddTicks(8248), "", "Berk Kalkan", "202cb962ac59075b964b07152d234b70", "pash" });
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Admin");

			migrationBuilder.DropTable(
				name: "Slayt");
		}
	}
}
