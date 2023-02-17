using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MappingSamples.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    City = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    City = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Workers");
        }
    }
}
