using AFFIFA.Domain.Entities;

namespace AFFIFA.Domain.Interfaces
{
    public interface ICampeonatoRepository
    {
        Task<IEnumerable<Campeonato>> GetAllCampeonatos();
        Task<IEnumerable<Campeonato>> GetCampeonatosByNome(string nome);        
        Task<Campeonato> GetCampeonatoById(int id);
        Task CreateCampeonato(Campeonato campeonato);
        Task UpdateCampeonato(Campeonato campeonato);
        Task DeleteCampeonato(Campeonato campeonato);
    }
}
