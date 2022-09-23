using AFFIFA.Domain.Entities;

namespace AFFIFA.Domain.Interfaces
{
    public interface IEquipeRepository
    {
        Task<EntidadeBase.Resposta> GetAllEquipes();
        Task<EntidadeBase.Resposta> GetEquipesByNome(string campeonatoNome);
        Task<EntidadeBase.Resposta> GetEquipeById(int equipeId);
        Task<EntidadeBase.Resposta> CreateEquipe(Equipe equipe);
        Task<EntidadeBase.Resposta> UpdateEquipe(Equipe equipe);
        Task<EntidadeBase.Resposta> DeleteEquipe(Equipe equipe);
    }
}
