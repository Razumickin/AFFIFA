using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AFFIFA.DataAccess.Migrations
{
    public partial class Mig_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campeonatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campeonatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CampeonatoEquipe",
                columns: table => new
                {
                    CampeonatosId = table.Column<int>(type: "int", nullable: false),
                    EquipesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampeonatoEquipe", x => new { x.CampeonatosId, x.EquipesId });
                    table.ForeignKey(
                        name: "FK_CampeonatoEquipe_Campeonatos_CampeonatosId",
                        column: x => x.CampeonatosId,
                        principalTable: "Campeonatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampeonatoEquipe_Equipes_EquipesId",
                        column: x => x.EquipesId,
                        principalTable: "Equipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampeonatoEquipe_EquipesId",
                table: "CampeonatoEquipe",
                column: "EquipesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampeonatoEquipe");

            migrationBuilder.DropTable(
                name: "Campeonatos");
        }
    }
}
