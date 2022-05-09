using Microsoft.EntityFrameworkCore.Migrations;

namespace TENNIS_APP.Migrations
{
    public partial class JSP2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_joueurs_RANKING_Our_RANK",
                table: "joueurs");

            migrationBuilder.DropIndex(
                name: "IX_joueurs_Our_RANK",
                table: "joueurs");

            migrationBuilder.DropColumn(
                name: "Our_RANK",
                table: "joueurs");

            migrationBuilder.DropColumn(
                name: "RANK_",
                table: "joueurs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Our_RANK",
                table: "joueurs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RANK_",
                table: "joueurs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_joueurs_Our_RANK",
                table: "joueurs",
                column: "Our_RANK");

            migrationBuilder.AddForeignKey(
                name: "FK_joueurs_RANKING_Our_RANK",
                table: "joueurs",
                column: "Our_RANK",
                principalSchema: "dbo",
                principalTable: "RANKING",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
