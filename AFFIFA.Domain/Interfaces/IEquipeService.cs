using AFFIFA.Domain.Entities;

namespace AFFIFA.Domain.Interfaces
{
    public interface IEquipeService
    {
        Task<IEnumerable<Equipe>> ListEquipes();
        Task<IEnumerable<Equipe>> ListEquipesByNome(string nome);
        Task<Equipe> GetEquipe(int id);        
        Task CreateEquipe(Equipe equipe);
        Task UpdateEquipe(Equipe equipe);
        Task DeleteEquipe(Equipe equipe);
    }
}
