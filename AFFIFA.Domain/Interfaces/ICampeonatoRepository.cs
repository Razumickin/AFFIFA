using AFFIFA.Domain.Entities;

namespace AFFIFA.Domain.Interfaces
{
    public interface ICampeonatoRepository
    {
        Task<Campeonato.Resposta> GetAllCampeonatos();
        Task<Campeonato.Resposta> GetCampeonatosByNome(string campeonatoNome);        
        Task<Campeonato.Resposta> GetCampeonatoById(int campeonatoId);
        Task<Campeonato.Resposta> CreateCampeonato(Campeonato campeonato);
        Task<Campeonato.Resposta> UpdateCampeonato(Campeonato campeonato);
        Task<Campeonato.Resposta> DeleteCampeonato(Campeonato campeonato);
        Task<Campeonato.Resposta> CreateCampeonatoEquipe(Campeonato campeonato, Equipe equipe);
    }
}
