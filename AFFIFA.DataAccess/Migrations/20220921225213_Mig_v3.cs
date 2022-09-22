using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AFFIFA.DataAccess.Migrations
{
    public partial class Mig_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MandanteId = table.Column<int>(type: "int", nullable: false),
                    VisitanteId = table.Column<int>(type: "int", nullable: false),
                    GolsMandante = table.Column<int>(type: "int", nullable: true),
                    GolsVisitante = table.Column<int>(type: "int", nullable: true),
                    CampeonatoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partidas_Campeonatos_CampeonatoId",
                        column: x => x.CampeonatoId,
                        principalTable: "Campeonatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partidas_Equipes_MandanteId",
                        column: x => x.MandanteId,
                        principalTable: "Equipes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partidas_Equipes_VisitanteId",
                        column: x => x.VisitanteId,
                        principalTable: "Equipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_CampeonatoId",
                table: "Partidas",
                column: "CampeonatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_MandanteId",
                table: "Partidas",
                column: "MandanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_VisitanteId",
                table: "Partidas",
                column: "VisitanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partidas");
        }
    }
}
