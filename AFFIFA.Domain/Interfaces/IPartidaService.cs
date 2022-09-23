using AFFIFA.Domain.Entities;

namespace AFFIFA.Domain.Interfaces
{
    public interface IPartidaService
    {
        Task<EntidadeBase.Resposta> GetPartidasByCampeonatoId(int campeonatoId);
        Task<EntidadeBase.Resposta> CreatePartida(Partida partida);
        Task<EntidadeBase.Resposta> UpdatePartida(Partida partida);
    }
}
