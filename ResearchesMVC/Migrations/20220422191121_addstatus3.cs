using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchesMVC.Migrations
{
    public partial class addstatus3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Status",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Status",
                newName: "status");
        }
    }
}
