
namespace AFFIFA.Domain.Entities
{
    public class Equipe
    {
        public int Id { get; set; }
        public string Nome { get; set; } = default!;
        public string Abreviacao { get; set; } = default!;
        public ICollection<Jogador>? Jogadores { get; set; }
        public ICollection<Campeonato>? Campeonatos { get; set; }
        public ICollection<Partida>? PartidasMandante { get; set; }
        public ICollection<Partida>? PartidasVisitante { get; set; }
    }
}
