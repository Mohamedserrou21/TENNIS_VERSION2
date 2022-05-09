using Microsoft.EntityFrameworkCore.Migrations;

namespace TENNIS_APP.Migrations
{
    public partial class modif : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subvention_Sponsor_NOM_TR",
                schema: "dbo",
                table: "Subvention");

            migrationBuilder.AddColumn<int>(
                name: "NOM_SPTR",
                schema: "dbo",
                table: "Subvention",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subvention_NOM_SPTR",
                schema: "dbo",
                table: "Subvention",
                column: "NOM_SPTR");

            migrationBuilder.AddForeignKey(
                name: "FK_Subvention_Sponsor_NOM_SPTR",
                schema: "dbo",
                table: "Subvention",
                column: "NOM_SPTR",
                principalSchema: "dbo",
                principalTable: "Sponsor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subvention_Sponsor_NOM_SPTR",
                schema: "dbo",
                table: "Subvention");

            migrationBuilder.DropIndex(
                name: "IX_Subvention_NOM_SPTR",
                schema: "dbo",
                table: "Subvention");

            migrationBuilder.DropColumn(
                name: "NOM_SPTR",
                schema: "dbo",
                table: "Subvention");

            migrationBuilder.AddForeignKey(
                name: "FK_Subvention_Sponsor_NOM_TR",
                schema: "dbo",
                table: "Subvention",
                column: "NOM_TR",
                principalSchema: "dbo",
                principalTable: "Sponsor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
