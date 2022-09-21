
namespace AFFIFA.Domain.Entities
{
    public class Jogador
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = default!;
        public string NomeCurto { get; set; } = default!;
        public int SofifaId { get; set; } = default!;
        public Equipe? Equipe { get; set; }
    }
}
