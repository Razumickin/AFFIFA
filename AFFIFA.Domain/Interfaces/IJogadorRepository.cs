using AFFIFA.Domain.Entities;

namespace AFFIFA.Domain.Interfaces
{
    public interface IJogadorRepository
    {
        Task<IEnumerable<Jogador>> GetAllJogadores();
        Task<IEnumerable<Jogador>> GetJogadoresByNome(string nome);
        Task<Jogador> GetJogadorById(int id);
        Task CreateJogador(Jogador jogador);
        Task UpdateJogador(Jogador jogador);
        Task DeleteJogador(Jogador jogador);
    }
}
