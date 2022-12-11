using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSoft.Data.Migrations
{
    public partial class parentIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Programs");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Parents");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Programs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
