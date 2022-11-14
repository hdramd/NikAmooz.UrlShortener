using Microsoft.EntityFrameworkCore.Migrations;

namespace NikAmooz.UrlShortener.Infrastructure.Migrations
{
    public partial class adddestinationfieldtoshortenurlentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "ShortUrls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrls_Path",
                table: "ShortUrls",
                column: "Path",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShortUrls_Path",
                table: "ShortUrls");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "ShortUrls");
        }
    }
}
