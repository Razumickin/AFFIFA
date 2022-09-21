using AFFIFA.Domain.Entities;

namespace AFFIFA.Domain.Interfaces
{
    public interface IEquipeRepository
    {
        Task<IEnumerable<Equipe>> GetEquipes();
        Task<IEnumerable<Equipe>> GetEquipes(string nome);
        Task<Equipe> GetEquipe(int id);
        Task CreateEquipe(Equipe equipe);
        Task UpdateEquipe(Equipe equipe);
        Task DeleteEquipe(Equipe equipe);
    }
}
