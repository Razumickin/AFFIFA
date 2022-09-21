using AFFIFA.Domain.Entities;

namespace AFFIFA.Domain.Interfaces
{
    public interface IJogadorService
    {
        Task<IEnumerable<Jogador>> ListJogadores();
        Task<IEnumerable<Jogador>> ListJogadoresByNome(string nome);
        Task<Jogador> GetJogador(int id);
        Task CreateJogador(Jogador jogador);
        Task UpdateJogador(Jogador jogador);
        Task DeleteJogador(Jogador jogador);
    }
}
