using AFFIFA.Domain.Entities;

namespace AFFIFA.Domain.Interfaces
{
    public interface IPartidaRepository
    {
        Task<EntidadeBase.Resposta> GetPartidasByCampeonatoId(int campeonatoId);
        Task<EntidadeBase.Resposta> CreatePartida(Partida partida);
        Task<EntidadeBase.Resposta> UpdatePartida(Partida partida);        
    }
}
