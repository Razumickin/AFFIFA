
namespace AFFIFA.Domain.Entities
{
    public class Partida : EntidadeBase
    {
        public int Id { get; set; }
        public Equipe Mandante { get; set; } = default!;
        public Equipe Visitante { get; set; } = default!;
        public int? GolsMandante { get; set; }
        public int? GolsVisitante { get; set; }
        public Campeonato Campeonato { get; set; } = default!;
    }
}
