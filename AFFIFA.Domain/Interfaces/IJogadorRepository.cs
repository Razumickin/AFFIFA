using AFFIFA.Domain.Entities;

namespace AFFIFA.Domain.Interfaces
{
    public interface IJogadorRepository
    {
        Task<IEnumerable<Jogador>> GetJogadores();
        Task<IEnumerable<Jogador>> GetJogadores(string nome);
        Task<Jogador> GetJogador(int id);
        Task CreateJogador(Jogador jogador);
        Task UpdateJogador(Jogador jogador);
        Task DeleteJogador(Jogador jogador);
    }
}
