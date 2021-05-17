using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBeauty.Data.Migrations
{
    public partial class skye35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "Salon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salon_CityID",
                table: "Salon",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Salon_City_CityID",
                table: "Salon",
                column: "CityID",
                principalTable: "City",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salon_City_CityID",
                table: "Salon");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropIndex(
                name: "IX_Salon_CityID",
                table: "Salon");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "Salon");
        }
    }
}
