using AFFIFA.Domain.Entities;

namespace AFFIFA.Domain.Interfaces
{
    public interface IEquipeRepository
    {
        Task<Equipe.Resposta> GetAllEquipes();
        Task<Equipe.Resposta> GetEquipesByNome(string campeonatoNome);
        Task<Equipe.Resposta> GetEquipeById(int equipeId);
        Task<Equipe.Resposta> CreateEquipe(Equipe equipe);
        Task<Equipe.Resposta> UpdateEquipe(Equipe equipe);
        Task<Equipe.Resposta> DeleteEquipe(Equipe equipe);
    }
}
