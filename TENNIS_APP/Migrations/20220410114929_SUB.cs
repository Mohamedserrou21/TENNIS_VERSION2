using Microsoft.EntityFrameworkCore.Migrations;

namespace TENNIS_APP.Migrations
{
    public partial class SUB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subvention",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MONTANT = table.Column<int>(nullable: false),
                    NOM_TR = table.Column<int>(nullable: false),
                    NAME_SPR = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subvention", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Subvention_Sponsor_NOM_TR",
                        column: x => x.NOM_TR,
                        principalSchema: "dbo",
                        principalTable: "Sponsor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subvention_Tournoi_NOM_TR",
                        column: x => x.NOM_TR,
                        principalSchema: "dbo",
                        principalTable: "Tournoi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subvention_NOM_TR",
                schema: "dbo",
                table: "Subvention",
                column: "NOM_TR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subvention",
                schema: "dbo");
        }
    }
}
