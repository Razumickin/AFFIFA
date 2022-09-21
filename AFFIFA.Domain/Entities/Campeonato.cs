using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFFIFA.Domain.Entities
{
    public class Campeonato
    {
        public int Id { get; set; }
        public string Nome { get; set; } = default!;
        public ICollection<Equipe>? Equipes { get; set; }
    }
}
