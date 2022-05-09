using Microsoft.EntityFrameworkCore.Migrations;

namespace TENNIS_APP.Migrations
{
    public partial class video : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Video",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Joueur_video = table.Column<int>(nullable: false),
                    Video_Joueur = table.Column<int>(nullable: true),
                    Video_Player = table.Column<string>(maxLength: 1000000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Video_joueurs_Video_Joueur",
                        column: x => x.Video_Joueur,
                        principalTable: "joueurs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Video_Video_Joueur",
                schema: "dbo",
                table: "Video",
                column: "Video_Joueur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Video",
                schema: "dbo");
        }
    }
}
