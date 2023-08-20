using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Korean_Api.Migrations
{
    /// <inheritdoc />
    public partial class rmvimg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "ActorsTable");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "ActorsTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
