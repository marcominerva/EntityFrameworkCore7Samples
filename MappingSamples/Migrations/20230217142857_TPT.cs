using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MappingSamples.Migrations
{
    /// <inheritdoc />
    public partial class TPT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "People");

            migrationBuilder.DropColumn(
                name: "IdentificationNumber",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "People");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_People_Id",
                        column: x => x.Id,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workers_People_Id",
                        column: x => x.Id,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Workers");

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

            migrationBuilder.AddColumn<int>(
                name: "Salary",
                table: "People",
                type: "int",
                nullable: true);
        }
    }
}
