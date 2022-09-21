using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;

namespace AFFIFA.Service
{
    public class EquipeService : IEquipeService
    {
        private readonly IEquipeRepository equipeRepository;
        public EquipeService(IEquipeRepository equipeRepository)
        {
            this.equipeRepository = equipeRepository;
        }

        public async Task<IEnumerable<Equipe>> ListEquipes()
        {
            return await equipeRepository.GetEquipes();
        }

        public async Task<IEnumerable<Equipe>> ListEquipesByNome(string nome)
        {
            return await equipeRepository.GetEquipes(nome);
        }

        public async Task<Equipe> GetEquipe(int id)
        {
            return await equipeRepository.GetEquipe(id);
        }

        public async Task CreateEquipe(Equipe equipe)
        {
            await equipeRepository.CreateEquipe(equipe);
        }

        public async Task UpdateEquipe(Equipe equipe)
        {
            await equipeRepository.UpdateEquipe(equipe);
        }

        public async Task DeleteEquipe(Equipe equipe)
        {
            await equipeRepository.DeleteEquipe(equipe);
        }
    }
}
