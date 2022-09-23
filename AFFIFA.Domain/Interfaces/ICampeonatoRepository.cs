using AFFIFA.Domain.Entities;

namespace AFFIFA.Domain.Interfaces
{
    public interface ICampeonatoRepository
    {
        Task<EntidadeBase.Resposta> GetAllCampeonatos();
        Task<EntidadeBase.Resposta> GetCampeonatosByNome(string campeonatoNome);        
        Task<EntidadeBase.Resposta> GetCampeonatoById(int campeonatoId);
        Task<EntidadeBase.Resposta> CreateCampeonato(Campeonato campeonato);
        Task<EntidadeBase.Resposta> UpdateCampeonato(Campeonato campeonato);
        Task<EntidadeBase.Resposta> DeleteCampeonato(Campeonato campeonato);
        Task<EntidadeBase.Resposta> CreateCampeonatoEquipe(Campeonato campeonato, Equipe equipe);
    }
}
