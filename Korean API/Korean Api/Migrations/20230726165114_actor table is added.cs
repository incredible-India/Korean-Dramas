using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Korean_Api.Migrations
{
    /// <inheritdoc />
    public partial class actortableisadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LeadActors",
                table: "LeadActors");

            migrationBuilder.RenameTable(
                name: "LeadActors",
                newName: "ActorsTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorsTable",
                table: "ActorsTable",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorsTable",
                table: "ActorsTable");

            migrationBuilder.RenameTable(
                name: "ActorsTable",
                newName: "LeadActors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeadActors",
                table: "LeadActors",
                column: "Id");
        }
    }
}
