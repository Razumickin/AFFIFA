using AFFIFA.Domain;
using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;

namespace AFFIFA.Service
{
    public class EquipeService : EntidadeBase, IEquipeService
    {
        private readonly IEquipeRepository equipeRepository;
        public EquipeService(IEquipeRepository equipeRepository)
        {
            this.equipeRepository = equipeRepository;
        }

        public async Task<IEnumerable<Equipe>> GetAllEquipes()
        {
            return await equipeRepository.GetAllEquipes();
        }

        public async Task<IEnumerable<Equipe>> GetEquipesByNome(string nome)
        {
            return await equipeRepository.GetEquipesByNome(nome);
        }

        public async Task<Equipe> GetEquipeById(int id)
        {
            return await equipeRepository.GetEquipeById(id);
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
