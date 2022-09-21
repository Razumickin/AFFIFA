using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AFFIFA.DataAccess.Migrations
{
    public partial class Mig_v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidas_Equipes_MandanteId",
                table: "Partidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidas_Equipes_VisitanteId",
                table: "Partidas");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidas_Equipes_MandanteId",
                table: "Partidas",
                column: "MandanteId",
                principalTable: "Equipes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidas_Equipes_VisitanteId",
                table: "Partidas",
                column: "VisitanteId",
                principalTable: "Equipes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidas_Equipes_MandanteId",
                table: "Partidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidas_Equipes_VisitanteId",
                table: "Partidas");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidas_Equipes_MandanteId",
                table: "Partidas",
                column: "MandanteId",
                principalTable: "Equipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidas_Equipes_VisitanteId",
                table: "Partidas",
                column: "VisitanteId",
                principalTable: "Equipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
