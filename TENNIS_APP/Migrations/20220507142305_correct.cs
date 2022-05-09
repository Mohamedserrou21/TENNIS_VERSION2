using Microsoft.EntityFrameworkCore.Migrations;

namespace TENNIS_APP.Migrations
{
    public partial class correct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Joueur_video",
                schema: "dbo",
                table: "Video",
                maxLength: 1000000,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Joueur_video",
                schema: "dbo",
                table: "Video",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000000);
        }
    }
}
