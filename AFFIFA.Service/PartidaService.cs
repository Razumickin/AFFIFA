using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;

namespace AFFIFA.Service
{
    public class PartidaService : IPartidaService
    {
        private readonly IPartidaRepository partidaRepository;
        public PartidaService(IPartidaRepository partidaRepository)
        {
            this.partidaRepository = partidaRepository;
        }

        public async Task<IEnumerable<Partida>> GetPartidasByCampeonatoId(int campeonatoId)
        {
            return await partidaRepository.GetPartidasByCampeonatoId(campeonatoId);
        }

        public async Task CreatePartida(Partida partida)
        {
            await partidaRepository.CreatePartida(partida);
        }        

        public async Task UpdatePartida(Partida partida)
        {
            await partidaRepository.UpdatePartida(partida);
        }
    }
}
