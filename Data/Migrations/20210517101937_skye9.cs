using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBeauty.Data.Migrations
{
    public partial class skye9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Appointment_TimeSpotID",
                table: "Appointment");

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    SalonsSalonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceID);
                    table.ForeignKey(
                        name: "FK_Service_Salon_SalonsSalonID",
                        column: x => x.SalonsSalonID,
                        principalTable: "Salon",
                        principalColumn: "SalonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_TimeSpotID",
                table: "Appointment",
                column: "TimeSpotID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Service_SalonsSalonID",
                table: "Service",
                column: "SalonsSalonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_TimeSpotID",
                table: "Appointment");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_TimeSpotID",
                table: "Appointment",
                column: "TimeSpotID");
        }
    }
}
