using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;

namespace AFFIFA.Service
{
    public class PartidaService : IPartidaService
    {
        private readonly IPartidaService partidaService;
        public PartidaService(IPartidaService partidaService)
        {
            this.partidaService = partidaService;
        }

        public async Task<IEnumerable<Partida>> GetPartidasByCampeonatoId(int campeonatoId)
        {
            return await partidaService.GetPartidasByCampeonatoId(campeonatoId);
        }

        public async Task CreatePartida(Partida partida)
        {
            await partidaService.CreatePartida(partida);
        }        

        public async Task UpdatePartida(Partida partida)
        {
            await partidaService.UpdatePartida(partida);
        }
    }
}
