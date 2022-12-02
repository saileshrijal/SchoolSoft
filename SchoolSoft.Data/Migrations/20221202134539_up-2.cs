using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSoft.Data.Migrations
{
    public partial class up2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Faculties",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Faculties",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Faculties",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Faculties",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Faculties",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Faculties",
                newName: "id");
        }
    }
}
