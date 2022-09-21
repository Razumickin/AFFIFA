using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;

namespace AFFIFA.Service
{
    public class JogadorService : IJogadorService
    {
        private readonly IJogadorRepository jogadorRepository;
        public JogadorService(IJogadorRepository jogadorRepository)
        {
            this.jogadorRepository = jogadorRepository;
        }

        public async Task<IEnumerable<Jogador>> ListJogadores()
        {
            return await jogadorRepository.GetJogadores();
        }

        public async Task<IEnumerable<Jogador>> ListJogadoresByNome(string nome)
        {
            return await jogadorRepository.GetJogadores(nome);
        }

        public async Task<Jogador> GetJogador(int id)
        {
            return await jogadorRepository.GetJogador(id);
        }

        public async Task CreateJogador(Jogador jogador)
        {
            await jogadorRepository.CreateJogador(jogador);
        }

        public async Task UpdateJogador(Jogador jogador)
        {
            await jogadorRepository.UpdateJogador(jogador);
        }

        public async Task DeleteJogador(Jogador jogador)
        {
            await jogadorRepository.DeleteJogador(jogador);
        }
    }
}
