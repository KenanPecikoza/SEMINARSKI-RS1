using Microsoft.EntityFrameworkCore.Migrations;

namespace eDnevnik.data.Migrations
{
    public partial class PredsjednikBlagajnik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_odjeljenje_ucenici_BlagajnikID",
                table: "odjeljenje");

            migrationBuilder.DropForeignKey(
                name: "FK_odjeljenje_ucenici_PredsjednikID",
                table: "odjeljenje");

            migrationBuilder.AddColumn<bool>(
                name: "Aktuelna",
                table: "skolskaGodina",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "PredsjednikID",
                table: "odjeljenje",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BlagajnikID",
                table: "odjeljenje",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_odjeljenje_ucenici_BlagajnikID",
                table: "odjeljenje",
                column: "BlagajnikID",
                principalTable: "ucenici",
                principalColumn: "UceniciID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_odjeljenje_ucenici_PredsjednikID",
                table: "odjeljenje",
                column: "PredsjednikID",
                principalTable: "ucenici",
                principalColumn: "UceniciID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_odjeljenje_ucenici_BlagajnikID",
                table: "odjeljenje");

            migrationBuilder.DropForeignKey(
                name: "FK_odjeljenje_ucenici_PredsjednikID",
                table: "odjeljenje");

            migrationBuilder.DropColumn(
                name: "Aktuelna",
                table: "skolskaGodina");

            migrationBuilder.AlterColumn<int>(
                name: "PredsjednikID",
                table: "odjeljenje",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BlagajnikID",
                table: "odjeljenje",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_odjeljenje_ucenici_BlagajnikID",
                table: "odjeljenje",
                column: "BlagajnikID",
                principalTable: "ucenici",
                principalColumn: "UceniciID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_odjeljenje_ucenici_PredsjednikID",
                table: "odjeljenje",
                column: "PredsjednikID",
                principalTable: "ucenici",
                principalColumn: "UceniciID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
