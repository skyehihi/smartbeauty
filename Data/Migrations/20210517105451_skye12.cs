using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBeauty.Data.Migrations
{
    public partial class skye12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_TimeSpot_TimeSpotID",
                table: "Appointment");

            migrationBuilder.DropTable(
                name: "TimeSpot");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_TimeSpotID",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "TimeSpotID",
                table: "Appointment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeSpotID",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TimeSpot",
                columns: table => new
                {
                    TimeSpotID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeSpotName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSpot", x => x.TimeSpotID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_TimeSpotID",
                table: "Appointment",
                column: "TimeSpotID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_TimeSpot_TimeSpotID",
                table: "Appointment",
                column: "TimeSpotID",
                principalTable: "TimeSpot",
                principalColumn: "TimeSpotID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
