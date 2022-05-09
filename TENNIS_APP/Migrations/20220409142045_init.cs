using Microsoft.EntityFrameworkCore.Migrations;

namespace TENNIS_APP.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "joueurs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOM = table.Column<string>(maxLength: 10, nullable: false),
                    PRENOM = table.Column<string>(maxLength: 10, nullable: false),
                    AGE = table.Column<int>(nullable: false),
                    NATIONALITE = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_joueurs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sponsor",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOM = table.Column<string>(maxLength: 10, nullable: false),
                    ADRESS = table.Column<string>(maxLength: 10, nullable: false),
                    CHIFFRE = table.Column<int>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tournoi",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOM = table.Column<string>(maxLength: 10, nullable: false),
                    PRIX = table.Column<int>(nullable: false),
                    DATE = table.Column<int>(nullable: false),
                    CAPACITE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournoi", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Gain",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_JOUEUR = table.Column<int>(nullable: false),
                    Nom_SPONSOR = table.Column<int>(nullable: false),
                    PRIME = table.Column<int>(nullable: false),
                    ANNEE = table.Column<int>(nullable: false),
                    ANNEE_TOURNOI = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gain", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Gain_Tournoi_ANNEE_TOURNOI",
                        column: x => x.ANNEE_TOURNOI,
                        principalSchema: "dbo",
                        principalTable: "Tournoi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Gain_joueurs_ID_JOUEUR",
                        column: x => x.ID_JOUEUR,
                        principalTable: "joueurs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gain_Sponsor_Nom_SPONSOR",
                        column: x => x.Nom_SPONSOR,
                        principalSchema: "dbo",
                        principalTable: "Sponsor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rencontre",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_Tournoi = table.Column<string>(nullable: false),
                    SCORE = table.Column<string>(nullable: false),
                    ID_Tournoi = table.Column<int>(nullable: false),
                    ID_Gagant = table.Column<int>(nullable: false),
                    ID_GAGNANT = table.Column<int>(nullable: true),
                    ID_PERDANT = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rencontre", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rencontre_joueurs_ID_GAGNANT",
                        column: x => x.ID_GAGNANT,
                        principalTable: "joueurs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rencontre_joueurs_ID_PERDANT",
                        column: x => x.ID_PERDANT,
                        principalTable: "joueurs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rencontre_Tournoi_ID_Tournoi",
                        column: x => x.ID_Tournoi,
                        principalSchema: "dbo",
                        principalTable: "Tournoi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gain_ANNEE_TOURNOI",
                schema: "dbo",
                table: "Gain",
                column: "ANNEE_TOURNOI");

            migrationBuilder.CreateIndex(
                name: "IX_Gain_ID_JOUEUR",
                schema: "dbo",
                table: "Gain",
                column: "ID_JOUEUR");

            migrationBuilder.CreateIndex(
                name: "IX_Gain_Nom_SPONSOR",
                schema: "dbo",
                table: "Gain",
                column: "Nom_SPONSOR");

            migrationBuilder.CreateIndex(
                name: "IX_Rencontre_ID_GAGNANT",
                schema: "dbo",
                table: "Rencontre",
                column: "ID_GAGNANT");

            migrationBuilder.CreateIndex(
                name: "IX_Rencontre_ID_PERDANT",
                schema: "dbo",
                table: "Rencontre",
                column: "ID_PERDANT");

            migrationBuilder.CreateIndex(
                name: "IX_Rencontre_ID_Tournoi",
                schema: "dbo",
                table: "Rencontre",
                column: "ID_Tournoi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gain",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Rencontre",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Sponsor",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "joueurs");

            migrationBuilder.DropTable(
                name: "Tournoi",
                schema: "dbo");
        }
    }
}
