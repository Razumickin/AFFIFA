using AFFIFA.Domain.Entities;

namespace AFFIFA.Domain.Interfaces
{
    public interface IPartidaService
    {
        Task<IEnumerable<Partida>> GetPartidasByCampeonatoId(int campeonatoId);
        Task CreatePartida(Partida partida);
        Task UpdatePartida(Partida partida);
    }
}
