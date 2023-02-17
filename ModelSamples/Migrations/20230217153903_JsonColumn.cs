using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelSamples.Migrations
{
    /// <inheritdoc />
    public partial class JsonColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "People",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);
        }
    }
}
