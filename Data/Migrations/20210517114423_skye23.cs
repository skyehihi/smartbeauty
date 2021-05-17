using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBeauty.Data.Migrations
{
    public partial class skye23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SalonService_ServiceID",
                table: "SalonService");

            migrationBuilder.CreateIndex(
                name: "IX_SalonService_ServiceID",
                table: "SalonService",
                column: "ServiceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SalonService_ServiceID",
                table: "SalonService");

            migrationBuilder.CreateIndex(
                name: "IX_SalonService_ServiceID",
                table: "SalonService",
                column: "ServiceID",
                unique: true);
        }
    }
}
