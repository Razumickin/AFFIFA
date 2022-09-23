using AFFIFA.Domain;
using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;

namespace AFFIFA.Service
{
    public class PartidaService : EntidadeBase, IPartidaService
    {
        private readonly IPartidaRepository partidaRepository;
        public PartidaService(IPartidaRepository partidaRepository)
        {
            this.partidaRepository = partidaRepository;
        }

        public async Task<Resposta> GetPartidasByCampeonatoId(int campeonatoId)
        {
            return await partidaRepository.GetPartidasByCampeonatoId(campeonatoId);
        }

        public async Task<Resposta> CreatePartida(Partida partida)
        {
            return await partidaRepository.CreatePartida(partida);
        }

        public async Task<Resposta> UpdatePartida(Partida partida)
        {
            return await partidaRepository.UpdatePartida(partida);
        }
    }
}
