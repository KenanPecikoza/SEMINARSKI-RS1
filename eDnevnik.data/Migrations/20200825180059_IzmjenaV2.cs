using Microsoft.EntityFrameworkCore.Migrations;

namespace eDnevnik.data.Migrations
{
    public partial class IzmjenaV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PredavaciPredmetiOdjeljenje_nastavnoOsoblje_NastavnoOsobljeID",
                table: "PredavaciPredmetiOdjeljenje");

            migrationBuilder.DropIndex(
                name: "IX_PredavaciPredmetiOdjeljenje_NastavnoOsobljeID",
                table: "PredavaciPredmetiOdjeljenje");

            migrationBuilder.DropColumn(
                name: "NastavnoOsobljeID",
                table: "PredavaciPredmetiOdjeljenje");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NastavnoOsobljeID",
                table: "PredavaciPredmetiOdjeljenje",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PredavaciPredmetiOdjeljenje_NastavnoOsobljeID",
                table: "PredavaciPredmetiOdjeljenje",
                column: "NastavnoOsobljeID");

            migrationBuilder.AddForeignKey(
                name: "FK_PredavaciPredmetiOdjeljenje_nastavnoOsoblje_NastavnoOsobljeID",
                table: "PredavaciPredmetiOdjeljenje",
                column: "NastavnoOsobljeID",
                principalTable: "nastavnoOsoblje",
                principalColumn: "NastavnoOsobljeID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
