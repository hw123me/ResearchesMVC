using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchesMVC.Migrations
{
    public partial class addOrderSamples : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderSamples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    StudySampleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSamples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderSamples_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderSamples_StudySamples_StudySampleId",
                        column: x => x.StudySampleId,
                        principalTable: "StudySamples",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderSamples_OrderId",
                table: "OrderSamples",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSamples_StudySampleId",
                table: "OrderSamples",
                column: "StudySampleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderSamples");
        }
    }
}
