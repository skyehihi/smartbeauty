using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBeauty.Data.Migrations
{
    public partial class skye32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Service");

            migrationBuilder.AddColumn<int>(
                name: "ServicePriceServiceID",
                table: "Service",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServicePrice",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePrice", x => x.ServiceID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_ServicePriceServiceID",
                table: "Service",
                column: "ServicePriceServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_ServicePrice_ServicePriceServiceID",
                table: "Service",
                column: "ServicePriceServiceID",
                principalTable: "ServicePrice",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_ServicePrice_ServicePriceServiceID",
                table: "Service");

            migrationBuilder.DropTable(
                name: "ServicePrice");

            migrationBuilder.DropIndex(
                name: "IX_Service_ServicePriceServiceID",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ServicePriceServiceID",
                table: "Service");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Service",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
