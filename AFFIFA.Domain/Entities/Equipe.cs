
namespace AFFIFA.Domain.Entities
{
    public class Equipe
    {
        public int Id { get; set; }
        public string Nome { get; set; } = default!;
        public string Abreviacao { get; set; } = default!;
        public ICollection<Campeonato>? Campeonatos { get; set; }
    }
}
