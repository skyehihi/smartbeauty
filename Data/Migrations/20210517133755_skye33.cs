using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBeauty.Data.Migrations
{
    public partial class skye33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_ServicePrice_ServicePriceServiceID",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_ServicePriceServiceID",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ServicePriceServiceID",
                table: "Service");

            migrationBuilder.AddColumn<int>(
                name: "ServicesServiceID",
                table: "ServicePrice",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServicePrice_ServicesServiceID",
                table: "ServicePrice",
                column: "ServicesServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePrice_Service_ServicesServiceID",
                table: "ServicePrice",
                column: "ServicesServiceID",
                principalTable: "Service",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicePrice_Service_ServicesServiceID",
                table: "ServicePrice");

            migrationBuilder.DropIndex(
                name: "IX_ServicePrice_ServicesServiceID",
                table: "ServicePrice");

            migrationBuilder.DropColumn(
                name: "ServicesServiceID",
                table: "ServicePrice");

            migrationBuilder.AddColumn<int>(
                name: "ServicePriceServiceID",
                table: "Service",
                type: "int",
                nullable: true);

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
    }
}
