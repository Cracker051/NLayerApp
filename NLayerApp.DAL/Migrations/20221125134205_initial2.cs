using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayerApp.DAL.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "surname",
                table: "Patients",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Patients",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "Doctors",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Doctors",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Patients",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Patients",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Doctors",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Doctors",
                newName: "name");
        }
    }
}
