using AFFIFA.Domain.Entities;

namespace AFFIFA.Domain.Interfaces
{
    public interface IEquipeRepository
    {
        Task<IEnumerable<Equipe>> GetAllEquipes();
        Task<IEnumerable<Equipe>> GetEquipesByNome(string nome);
        Task<Equipe> GetEquipeById(int id);
        Task CreateEquipe(Equipe equipe);
        Task UpdateEquipe(Equipe equipe);
        Task DeleteEquipe(Equipe equipe);
    }
}
