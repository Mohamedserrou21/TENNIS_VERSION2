using Microsoft.EntityFrameworkCore.Migrations;

namespace TENNIS_APP.Migrations
{
    public partial class score : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SCORE",
                schema: "dbo",
                table: "RANKING",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SCORE",
                schema: "dbo",
                table: "RANKING",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
