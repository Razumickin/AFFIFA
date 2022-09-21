
namespace AFFIFA.Domain.Entities
{
    public class Campeonato
    {
        public int Id { get; set; }
        public string Nome { get; set; } = default!;
        public ICollection<Equipe>? Equipes { get; set; }
        public ICollection<Partida> Partidas { get; set; }
    }
}
