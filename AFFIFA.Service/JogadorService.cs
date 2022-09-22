using AFFIFA.Domain;
using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;

namespace AFFIFA.Service
{
    public class JogadorService : EntidadeBase, IJogadorService
    {
        private readonly IJogadorRepository jogadorRepository;
        public JogadorService(IJogadorRepository jogadorRepository)
        {
            this.jogadorRepository = jogadorRepository;
        }

        public async Task<IEnumerable<Jogador>> GetAllJogadores()
        {
            return await jogadorRepository.GetAllJogadores();
        }

        public async Task<IEnumerable<Jogador>> GetJogadoresByNome(string nome)
        {
            return await jogadorRepository.GetJogadoresByNome(nome);
        }

        public async Task<Jogador> GetJogadorById(int id)
        {
            return await jogadorRepository.GetJogadorById(id);
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
