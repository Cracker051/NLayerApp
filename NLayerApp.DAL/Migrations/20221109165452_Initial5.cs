using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayerApp.DAL.Migrations
{
    public partial class Initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Full_name",
                table: "Patients",
                newName: "surname");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Patients",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "Patients",
                newName: "Full_name");
        }
    }
}
