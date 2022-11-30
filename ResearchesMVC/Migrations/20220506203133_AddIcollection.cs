using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchesMVC.Migrations
{
    public partial class AddIcollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderTools_Orders_OrderId",
                table: "OrderTools");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTools_StudyTools_StudyToolId",
                table: "OrderTools");

            migrationBuilder.AlterColumn<int>(
                name: "StudyToolId",
                table: "OrderTools",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderTools",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTools_Orders_OrderId",
                table: "OrderTools",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTools_StudyTools_StudyToolId",
                table: "OrderTools",
                column: "StudyToolId",
                principalTable: "StudyTools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderTools_Orders_OrderId",
                table: "OrderTools");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTools_StudyTools_StudyToolId",
                table: "OrderTools");

            migrationBuilder.AlterColumn<int>(
                name: "StudyToolId",
                table: "OrderTools",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderTools",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTools_Orders_OrderId",
                table: "OrderTools",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTools_StudyTools_StudyToolId",
                table: "OrderTools",
                column: "StudyToolId",
                principalTable: "StudyTools",
                principalColumn: "Id");
        }
    }
}
