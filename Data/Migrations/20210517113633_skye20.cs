using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBeauty.Data.Migrations
{
    public partial class skye20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Salon_SalonsSalonID",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_SalonsSalonID",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_SalonService_ServiceID",
                table: "SalonService");

            migrationBuilder.DropColumn(
                name: "SalonsSalonID",
                table: "Service");

            migrationBuilder.CreateIndex(
                name: "IX_SalonService_ServiceID",
                table: "SalonService",
                column: "ServiceID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SalonService_ServiceID",
                table: "SalonService");

            migrationBuilder.AddColumn<int>(
                name: "SalonsSalonID",
                table: "Service",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Service_SalonsSalonID",
                table: "Service",
                column: "SalonsSalonID");

            migrationBuilder.CreateIndex(
                name: "IX_SalonService_ServiceID",
                table: "SalonService",
                column: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Salon_SalonsSalonID",
                table: "Service",
                column: "SalonsSalonID",
                principalTable: "Salon",
                principalColumn: "SalonID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
