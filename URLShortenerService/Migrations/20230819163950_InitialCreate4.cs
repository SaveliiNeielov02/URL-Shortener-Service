using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URLShortenerService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Records",
                table: "Records");

            migrationBuilder.RenameColumn(
                name: "URL",
                table: "Records",
                newName: "LongURL");

            migrationBuilder.AddColumn<string>(
                name: "ShortURL",
                table: "Records",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Records",
                table: "Records",
                column: "ShortURL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Records",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "ShortURL",
                table: "Records");

            migrationBuilder.RenameColumn(
                name: "LongURL",
                table: "Records",
                newName: "URL");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Records",
                table: "Records",
                column: "URL");
        }
    }
}
