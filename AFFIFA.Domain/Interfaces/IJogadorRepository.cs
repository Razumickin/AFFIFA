using AFFIFA.Domain.Entities;

namespace AFFIFA.Domain.Interfaces
{
    public interface IJogadorRepository
    {
        Task<EntidadeBase.Resposta> GetAllJogadores();
        Task<EntidadeBase.Resposta> GetJogadoresByNome(string jogadorNome);
        Task<EntidadeBase.Resposta> GetJogadorById(int jogadorId);
        Task<EntidadeBase.Resposta> CreateJogador(Jogador jogador);
        Task<EntidadeBase.Resposta> UpdateJogador(Jogador jogador);
        Task<EntidadeBase.Resposta> DeleteJogador(Jogador jogador);
    }
}
