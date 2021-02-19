using Microsoft.EntityFrameworkCore.Migrations;

namespace eDnevnik.data.Migrations
{
    public partial class aktivnoOdjeljenje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aktivno",
                table: "odjeljenje",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aktivno",
                table: "odjeljenje");
        }
    }
}
