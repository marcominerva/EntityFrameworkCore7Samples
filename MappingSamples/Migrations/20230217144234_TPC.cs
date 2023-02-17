using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MappingSamples.Migrations
{
    /// <inheritdoc />
    public partial class TPC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_People_Id",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_People_Id",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Workers",
                type: "varchar(max)",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Workers",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Workers",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Students",
                type: "varchar(max)",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Students",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Students");

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    FirstName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Students_People_Id",
                table: "Students",
                column: "Id",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_People_Id",
                table: "Workers",
                column: "Id",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
