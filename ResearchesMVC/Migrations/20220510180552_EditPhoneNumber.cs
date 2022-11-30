using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchesMVC.Migrations
{
    public partial class EditPhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderSamples_Orders_OrderId",
                table: "OrderSamples");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSamples_StudySamples_StudySampleId",
                table: "OrderSamples");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "StudySampleId",
                table: "OrderSamples",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderSamples",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSamples_Orders_OrderId",
                table: "OrderSamples",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSamples_StudySamples_StudySampleId",
                table: "OrderSamples",
                column: "StudySampleId",
                principalTable: "StudySamples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderSamples_Orders_OrderId",
                table: "OrderSamples");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSamples_StudySamples_StudySampleId",
                table: "OrderSamples");

            migrationBuilder.AlterColumn<int>(
                name: "StudySampleId",
                table: "OrderSamples",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderSamples",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSamples_Orders_OrderId",
                table: "OrderSamples",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSamples_StudySamples_StudySampleId",
                table: "OrderSamples",
                column: "StudySampleId",
                principalTable: "StudySamples",
                principalColumn: "Id");
        }
    }
}
