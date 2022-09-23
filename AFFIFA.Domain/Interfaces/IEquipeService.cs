using AFFIFA.Domain.Entities;

namespace AFFIFA.Domain.Interfaces
{
    public interface IEquipeService
    {
        Task<EntidadeBase.Resposta> GetAllEquipes();
        Task<EntidadeBase.Resposta> GetEquipesByNome(string equipeNome);
        Task<EntidadeBase.Resposta> GetEquipeById(int equipeId);
        Task<EntidadeBase.Resposta> CreateEquipe(Equipe equipe);
        Task<EntidadeBase.Resposta> UpdateEquipe(int equipeId, Equipe equipe);
        Task<EntidadeBase.Resposta> DeleteEquipe(int equipeId);
    }
}
