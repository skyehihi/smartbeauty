using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBeauty.Data.Migrations
{
    public partial class skye27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Salon_SalonID",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_SalonID",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "SalonID",
                table: "Service");

            migrationBuilder.CreateTable(
                name: "SalonService",
                columns: table => new
                {
                    SalonID = table.Column<int>(type: "int", nullable: false),
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalonService", x => new { x.SalonID, x.ServiceID });
                    table.ForeignKey(
                        name: "FK_SalonService_Salon_SalonID",
                        column: x => x.SalonID,
                        principalTable: "Salon",
                        principalColumn: "SalonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalonService_Service_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Service",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalonService_ServiceID",
                table: "SalonService",
                column: "ServiceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalonService");

            migrationBuilder.AddColumn<int>(
                name: "SalonID",
                table: "Service",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Service_SalonID",
                table: "Service",
                column: "SalonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Salon_SalonID",
                table: "Service",
                column: "SalonID",
                principalTable: "Salon",
                principalColumn: "SalonID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
