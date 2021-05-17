using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBeauty.Data.Migrations
{
    public partial class Trang1 : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "SalonName",
                table: "Salon",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "SalonName",
                table: "Salon",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

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
