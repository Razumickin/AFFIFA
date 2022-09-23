using AFFIFA.Domain.Entities;

namespace AFFIFA.Domain.Interfaces
{
    public interface IEquipeService
    {
        Task<Equipe.Resposta> GetAllEquipes();
        Task<Equipe.Resposta> GetEquipesByNome(string equipeNome);
        Task<Equipe.Resposta> GetEquipeById(int equipeId);        
        Task<Equipe.Resposta> CreateEquipe(Equipe equipe);
        Task<Equipe.Resposta> UpdateEquipe(int equipeId, Equipe equipe);
        Task<Equipe.Resposta> DeleteEquipe(int equipeId);
    }
}
