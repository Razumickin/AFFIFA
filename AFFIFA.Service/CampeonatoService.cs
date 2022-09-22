using AFFIFA.Domain;
using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;

namespace AFFIFA.Service
{
    public class CampeonatoService : EntidadeBase, ICampeonatoService
    {
        private readonly ICampeonatoRepository campeonatoRepository;
        private readonly IEquipeRepository equipeRepository;
        public CampeonatoService(ICampeonatoRepository campeonatoRepository, IEquipeRepository equipeRepository)
        {
            this.campeonatoRepository = campeonatoRepository;
            this.equipeRepository = equipeRepository;
        }

        public async Task<Resposta> GetAllCampeonatos()
        {
            return await campeonatoRepository.GetAllCampeonatos();
        }

        public async Task<Resposta> GetCampeonatosByNome(string campeonatoNome)
        {
            return await campeonatoRepository.GetCampeonatosByNome(campeonatoNome);
        }

        public async Task<Resposta> GetCampeonatoById(int campeonatoId)
        {
            return await campeonatoRepository.GetCampeonatoById(campeonatoId);
        }

        public async Task<Resposta> CreateCampeonato(Campeonato campeonato)
        {
            /*IEnumerable<IEnumerable<int>> combinacoes = campeonato.GerarPartidas();
            int[,] arr = new int[12,2];
            int count = 0;

            foreach (var combinaco in combinacoes)
            {
                arr[count, 0] = combinaco.ElementAt(0);
                arr[count, 1] = combinaco.ElementAt(1);
                count++;
            }*/
            
            return await campeonatoRepository.CreateCampeonato(campeonato);            
        }

        public async Task<Resposta> UpdateCampeonato(int campeonatoId, Campeonato campeonato)
        {
            if (campeonato.Id != campeonatoId)
            {
                return new Resposta(Status400BadRequest, "Erro nos parâmetros da requisição.");
            }

            return await campeonatoRepository.UpdateCampeonato(campeonato);
        }

        public async Task<Resposta> DeleteCampeonato(int campeonatoId)
        {
            Resposta resposta = await GetCampeonatoById(campeonatoId);
            if (resposta.Status != Status200OK)
            {
                return resposta;
            }

            return await campeonatoRepository.DeleteCampeonato((Campeonato)resposta.Objeto);
        }

        public async Task<Resposta> CreateCampeonatoEquipe(int campeonatoId, int equipeId)
        {        
            //Resposta equipe = await new EquipeService(equipeRepository).GetEquipeById(EquipeId);
            Resposta campeonato = await GetCampeonatoById(campeonatoId);
            return new Resposta(Status200OK, "");
        }
    }
}
