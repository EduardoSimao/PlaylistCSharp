using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class PKAlbum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantorID",
                table: "Albuns",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Albuns_CantorID",
                table: "Albuns",
                column: "CantorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Albuns_Cantores_CantorID",
                table: "Albuns",
                column: "CantorID",
                principalTable: "Cantores",
                principalColumn: "CantorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albuns_Cantores_CantorID",
                table: "Albuns");

            migrationBuilder.DropIndex(
                name: "IX_Albuns_CantorID",
                table: "Albuns");

            migrationBuilder.DropColumn(
                name: "CantorID",
                table: "Albuns");
        }
    }
}
