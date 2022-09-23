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

        public async Task<Resposta> GetAllJogadores()
        {
            return await jogadorRepository.GetAllJogadores();
        }

        public async Task<Resposta> GetJogadoresByNome(string jogadorNome)
        {
            return await jogadorRepository.GetJogadoresByNome(jogadorNome);
        }

        public async Task<Resposta> GetJogadorById(int jogadorId)
        {
            return await jogadorRepository.GetJogadorById(jogadorId);
        }

        public async Task<Resposta> CreateJogador(Jogador jogador)
        {
            return await jogadorRepository.CreateJogador(jogador);
        }

        public async Task<Resposta> UpdateJogador(int jogadorId, Jogador jogador)
        {
            if(jogador.Id != jogadorId)
            {
                return new Resposta(Status400BadRequest, "Erro nos parâmetros da requisição.");
            }

            return await jogadorRepository.UpdateJogador(jogador);
        }

        public async Task<Resposta> DeleteJogador(int jogadorId)
        {
            Resposta resposta = await GetJogadorById(jogadorId);
            if (resposta.Status != Status200OK)
            {
                return resposta;
            }

            return await jogadorRepository.DeleteJogador((Jogador)resposta.Objeto);
        }
    }
}
