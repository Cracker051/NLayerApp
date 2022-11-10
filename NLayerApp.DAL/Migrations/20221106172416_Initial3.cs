using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayerApp.DAL.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Full_name",
                table: "Doctors",
                newName: "surname");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Doctors",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "Doctors",
                newName: "Full_name");
        }
    }
}
