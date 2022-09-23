using AFFIFA.Domain.Entities;

namespace AFFIFA.Domain.Interfaces
{
    public interface ICampeonatoService
    {
        Task<EntidadeBase.Resposta> GetAllCampeonatos();
        Task<EntidadeBase.Resposta> GetCampeonatosByNome(string campeonatoNome);
        Task<EntidadeBase.Resposta> GetCampeonatoById(int campeonatoId);
        Task<EntidadeBase.Resposta> CreateCampeonato(Campeonato campeonato);        
        Task<EntidadeBase.Resposta> UpdateCampeonato(int campeonatoId, Campeonato campeonato);
        Task<EntidadeBase.Resposta> DeleteCampeonato(int campeonatoId);
        Task<EntidadeBase.Resposta> CreateCampeonatoEquipe(int campeonatoId, int equipeId);
    }
}
