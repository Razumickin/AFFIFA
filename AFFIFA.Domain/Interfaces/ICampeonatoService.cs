using AFFIFA.Domain.Entities;

namespace AFFIFA.Domain.Interfaces
{
    public interface ICampeonatoService
    {
        Task<Campeonato.Resposta> GetAllCampeonatos();
        Task<Campeonato.Resposta> GetCampeonatosByNome(string campeonatoNome);
        Task<Campeonato.Resposta> GetCampeonatoById(int campeonatoId);
        Task<Campeonato.Resposta> CreateCampeonato(Campeonato campeonato);        
        Task<Campeonato.Resposta> UpdateCampeonato(int campeonatoId, Campeonato campeonato);
        Task<Campeonato.Resposta> DeleteCampeonato(int campeonatoId);
        Task<Campeonato.Resposta> CreateCampeonatoEquipe(int campeonatoId, int equipeId);
    }
}
