using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;

namespace AFFIFA.Service
{
    public class CampeonatoService : ICampeonatoService
    {
        private readonly ICampeonatoRepository campeonatoRepository;
        public CampeonatoService(ICampeonatoRepository campeonatoRepository)
        {
            this.campeonatoRepository = campeonatoRepository;
        }

        public async Task<IEnumerable<Campeonato>> GetAllCampeonatos()
        {
            return await campeonatoRepository.GetAllCampeonatos();
        }

        public async Task<IEnumerable<Campeonato>> GetCampeonatosByNome(string nome)
        {
            return await campeonatoRepository.GetCampeonatosByNome(nome);
        }

        public async Task<Campeonato> GetCampeonatoById(int id)
        {
            return await campeonatoRepository.GetCampeonatoById(id);
        }

        public async Task CreateCampeonato(Campeonato campeonato)
        {
            await campeonatoRepository.CreateCampeonato(campeonato);
        }

        public async Task UpdateCampeonato(Campeonato campeonato)
        {
            await campeonatoRepository.UpdateCampeonato(campeonato);
        }

        public async Task DeleteCampeonato(Campeonato campeonato)
        {
            await campeonatoRepository.DeleteCampeonato(campeonato);
        }
    }
}
