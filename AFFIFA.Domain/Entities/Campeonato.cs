
namespace AFFIFA.Domain.Entities
{
    public class Campeonato : EntidadeBase
    {
        public int Id { get; set; }
        public string Nome { get; set; } = default!;
        public ICollection<Equipe>? Equipes { get; set; }

        public Campeonato()
        {
            Equipes = new HashSet<Equipe>();
        }

        private IEnumerable<IEnumerable<int>> GerarCombinacoes(IEnumerable<int> equipes, int fator = 2)
        {
            if(fator == 1)
            {
                return equipes.Select(eqp => new int[] { eqp });
            }

            Resposta resposta = new Resposta(Status200OK, equipes);

            return GerarCombinacoes(equipes, fator - 1).SelectMany(eqp => equipes.Where(obj => !eqp.Contains(obj)), (eqp1, eqp2) => eqp1.Concat(new int[] { eqp2 }));
        }

        public IEnumerable<IEnumerable<int>> GerarPartidas()
        {
            return GerarCombinacoes(new int[] {1,2,3,4});
        }
    }
}
