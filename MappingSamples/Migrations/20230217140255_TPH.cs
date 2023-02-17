using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MappingSamples.Migrations
{
    /// <inheritdoc />
    public partial class TPH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workers",
                table: "Workers");

            migrationBuilder.RenameTable(
                name: "Workers",
                newName: "People");

            migrationBuilder.AlterColumn<int>(
                name: "Salary",
                table: "People",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "People",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentificationNumber",
                table: "People",
                type: "varchar(6)",
                unicode: false,
                maxLength: 6,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "People");

            migrationBuilder.DropColumn(
                name: "IdentificationNumber",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Workers");

            migrationBuilder.AlterColumn<int>(
                name: "Salary",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workers",
                table: "Workers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    FirstName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    IdentificationNumber = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }
    }
}
