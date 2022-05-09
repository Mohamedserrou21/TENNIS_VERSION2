using Microsoft.EntityFrameworkCore.Migrations;

namespace TENNIS_APP.Migrations
{
    public partial class rank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RANKING",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SCORE = table.Column<string>(nullable: false),
                    RANK = table.Column<string>(nullable: false),
                    RANK_PLAYER = table.Column<int>(nullable: false),
                    ID_Player_RANK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RANKING", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RANKING_joueurs_ID_Player_RANK",
                        column: x => x.ID_Player_RANK,
                        principalTable: "joueurs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RANKING_ID_Player_RANK",
                schema: "dbo",
                table: "RANKING",
                column: "ID_Player_RANK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RANKING",
                schema: "dbo");
        }
    }
}
