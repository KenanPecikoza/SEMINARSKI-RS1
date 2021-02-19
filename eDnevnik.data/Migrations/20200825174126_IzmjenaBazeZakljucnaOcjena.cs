using Microsoft.EntityFrameworkCore.Migrations;

namespace eDnevnik.data.Migrations
{
    public partial class IzmjenaBazeZakljucnaOcjena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_slusaPredmet_uceniciOdjeljenje_UceniciID_OdjeljenjeID",
                table: "slusaPredmet");

            migrationBuilder.DropForeignKey(
                name: "FK_slusaPredmet_PredavaciPredmetiOdjeljenje_NastavnoOsobljeID_PredmetID_OdjeljenjeID",
                table: "slusaPredmet");

            migrationBuilder.DropTable(
                name: "sekcijeUcenici");

            migrationBuilder.DropTable(
                name: "skolskeSekcije");

            migrationBuilder.DropPrimaryKey(
                name: "PK_uceniciOdjeljenje",
                table: "uceniciOdjeljenje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_slusaPredmet",
                table: "slusaPredmet");

            migrationBuilder.DropIndex(
                name: "IX_slusaPredmet_UceniciID_OdjeljenjeID",
                table: "slusaPredmet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PredavaciPredmetiOdjeljenje",
                table: "PredavaciPredmetiOdjeljenje");

            migrationBuilder.DropColumn(
                name: "NastavnoOsobljeID",
                table: "slusaPredmet");

            migrationBuilder.DropColumn(
                name: "PredmetID",
                table: "slusaPredmet");

            migrationBuilder.DropColumn(
                name: "OdjeljenjeID",
                table: "slusaPredmet");

            migrationBuilder.DropColumn(
                name: "UceniciID",
                table: "slusaPredmet");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "uceniciOdjeljenje",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "slusaPredmet",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "predavaciPredmetiOdjeljenjeId",
                table: "slusaPredmet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "uceniciOdjeljenjeId",
                table: "slusaPredmet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PredavaciPredmetiOdjeljenje",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_uceniciOdjeljenje",
                table: "uceniciOdjeljenje",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_slusaPredmet",
                table: "slusaPredmet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PredavaciPredmetiOdjeljenje",
                table: "PredavaciPredmetiOdjeljenje",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_uceniciOdjeljenje_odjeljenjeID",
                table: "uceniciOdjeljenje",
                column: "odjeljenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_slusaPredmet_predavaciPredmetiOdjeljenjeId",
                table: "slusaPredmet",
                column: "predavaciPredmetiOdjeljenjeId");

            migrationBuilder.CreateIndex(
                name: "IX_slusaPredmet_uceniciOdjeljenjeId",
                table: "slusaPredmet",
                column: "uceniciOdjeljenjeId");

            migrationBuilder.CreateIndex(
                name: "IX_PredavaciPredmetiOdjeljenje_NastavnoOsobljeID",
                table: "PredavaciPredmetiOdjeljenje",
                column: "NastavnoOsobljeID");

            migrationBuilder.AddForeignKey(
                name: "FK_slusaPredmet_PredavaciPredmetiOdjeljenje_predavaciPredmetiOdjeljenjeId",
                table: "slusaPredmet",
                column: "predavaciPredmetiOdjeljenjeId",
                principalTable: "PredavaciPredmetiOdjeljenje",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_slusaPredmet_uceniciOdjeljenje_uceniciOdjeljenjeId",
                table: "slusaPredmet",
                column: "uceniciOdjeljenjeId",
                principalTable: "uceniciOdjeljenje",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_slusaPredmet_PredavaciPredmetiOdjeljenje_predavaciPredmetiOdjeljenjeId",
                table: "slusaPredmet");

            migrationBuilder.DropForeignKey(
                name: "FK_slusaPredmet_uceniciOdjeljenje_uceniciOdjeljenjeId",
                table: "slusaPredmet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_uceniciOdjeljenje",
                table: "uceniciOdjeljenje");

            migrationBuilder.DropIndex(
                name: "IX_uceniciOdjeljenje_odjeljenjeID",
                table: "uceniciOdjeljenje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_slusaPredmet",
                table: "slusaPredmet");

            migrationBuilder.DropIndex(
                name: "IX_slusaPredmet_predavaciPredmetiOdjeljenjeId",
                table: "slusaPredmet");

            migrationBuilder.DropIndex(
                name: "IX_slusaPredmet_uceniciOdjeljenjeId",
                table: "slusaPredmet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PredavaciPredmetiOdjeljenje",
                table: "PredavaciPredmetiOdjeljenje");

            migrationBuilder.DropIndex(
                name: "IX_PredavaciPredmetiOdjeljenje_NastavnoOsobljeID",
                table: "PredavaciPredmetiOdjeljenje");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "uceniciOdjeljenje");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "slusaPredmet");

            migrationBuilder.DropColumn(
                name: "predavaciPredmetiOdjeljenjeId",
                table: "slusaPredmet");

            migrationBuilder.DropColumn(
                name: "uceniciOdjeljenjeId",
                table: "slusaPredmet");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PredavaciPredmetiOdjeljenje");

            migrationBuilder.AddColumn<int>(
                name: "NastavnoOsobljeID",
                table: "slusaPredmet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PredmetID",
                table: "slusaPredmet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OdjeljenjeID",
                table: "slusaPredmet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UceniciID",
                table: "slusaPredmet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_uceniciOdjeljenje",
                table: "uceniciOdjeljenje",
                columns: new[] { "odjeljenjeID", "uceniciID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_slusaPredmet",
                table: "slusaPredmet",
                columns: new[] { "NastavnoOsobljeID", "PredmetID", "OdjeljenjeID", "UceniciID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PredavaciPredmetiOdjeljenje",
                table: "PredavaciPredmetiOdjeljenje",
                columns: new[] { "NastavnoOsobljeID", "PredmetiID", "odjeljenjeID" });

            migrationBuilder.CreateTable(
                name: "skolskeSekcije",
                columns: table => new
                {
                    SkolskeSekcijeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivSekcije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PredavaciNastavnoOsobljeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skolskeSekcije", x => x.SkolskeSekcijeID);
                    table.ForeignKey(
                        name: "FK_skolskeSekcije_nastavnoOsoblje_PredavaciNastavnoOsobljeID",
                        column: x => x.PredavaciNastavnoOsobljeID,
                        principalTable: "nastavnoOsoblje",
                        principalColumn: "NastavnoOsobljeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sekcijeUcenici",
                columns: table => new
                {
                    skolskeSekcijeID = table.Column<int>(type: "int", nullable: false),
                    uceniciID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sekcijeUcenici", x => new { x.skolskeSekcijeID, x.uceniciID });
                    table.ForeignKey(
                        name: "FK_sekcijeUcenici_skolskeSekcije_skolskeSekcijeID",
                        column: x => x.skolskeSekcijeID,
                        principalTable: "skolskeSekcije",
                        principalColumn: "SkolskeSekcijeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_sekcijeUcenici_ucenici_uceniciID",
                        column: x => x.uceniciID,
                        principalTable: "ucenici",
                        principalColumn: "UceniciID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_slusaPredmet_UceniciID_OdjeljenjeID",
                table: "slusaPredmet",
                columns: new[] { "UceniciID", "OdjeljenjeID" });

            migrationBuilder.CreateIndex(
                name: "IX_sekcijeUcenici_uceniciID",
                table: "sekcijeUcenici",
                column: "uceniciID");

            migrationBuilder.CreateIndex(
                name: "IX_skolskeSekcije_PredavaciNastavnoOsobljeID",
                table: "skolskeSekcije",
                column: "PredavaciNastavnoOsobljeID");

            migrationBuilder.AddForeignKey(
                name: "FK_slusaPredmet_uceniciOdjeljenje_UceniciID_OdjeljenjeID",
                table: "slusaPredmet",
                columns: new[] { "UceniciID", "OdjeljenjeID" },
                principalTable: "uceniciOdjeljenje",
                principalColumns: new[] { "odjeljenjeID", "uceniciID" },
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_slusaPredmet_PredavaciPredmetiOdjeljenje_NastavnoOsobljeID_PredmetID_OdjeljenjeID",
                table: "slusaPredmet",
                columns: new[] { "NastavnoOsobljeID", "PredmetID", "OdjeljenjeID" },
                principalTable: "PredavaciPredmetiOdjeljenje",
                principalColumns: new[] { "NastavnoOsobljeID", "PredmetiID", "odjeljenjeID" },
                onDelete: ReferentialAction.NoAction);
        }
    }
}
