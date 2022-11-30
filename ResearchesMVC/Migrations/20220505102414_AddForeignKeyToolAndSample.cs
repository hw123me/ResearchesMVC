using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchesMVC.Migrations
{
    public partial class AddForeignKeyToolAndSample : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudySampleId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudyToolId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StudySampleId",
                table: "Orders",
                column: "StudySampleId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StudyToolId",
                table: "Orders",
                column: "StudyToolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_StudySamples_StudySampleId",
                table: "Orders",
                column: "StudySampleId",
                principalTable: "StudySamples",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_StudyTools_StudyToolId",
                table: "Orders",
                column: "StudyToolId",
                principalTable: "StudyTools",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_StudySamples_StudySampleId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_StudyTools_StudyToolId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StudySampleId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StudyToolId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StudySampleId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StudyToolId",
                table: "Orders");
        }
    }
}
