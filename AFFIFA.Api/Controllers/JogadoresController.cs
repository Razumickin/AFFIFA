using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static AFFIFA.Domain.EntidadeBase;

namespace AFFIFA.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class JogadoresController : ControllerBase
    {
        private readonly IJogadorService jogadorService;
        public JogadoresController(IJogadorService jogadorService)
        {
            this.jogadorService = jogadorService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Jogador>>> ListJogadores()
        {
            try
            {
                Resposta resposta = await jogadorService.GetAllJogadores();
                return StatusCode(resposta.Status, resposta.Objeto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{jogadorNome:alpha}")]
        public async Task<ActionResult<IAsyncEnumerable<Jogador>>> ListJogadoresByNome(string jogadorNome)
        {
            try
            {
                Resposta resposta = await jogadorService.GetJogadoresByNome(jogadorNome);
                return StatusCode(resposta.Status, resposta.Objeto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("jogador/{jogadorId}", Name = "GetJogadorById")]
        public async Task<ActionResult<Jogador>> GetJogadorById(int jogadorId)
        {
            try
            {
                Resposta resposta = await jogadorService.GetJogadorById(jogadorId);
                return StatusCode(resposta.Status, resposta.Objeto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateJogador(Jogador jogador)
        {
            try
            {
                Resposta resposta = await jogadorService.CreateJogador(jogador);
                if(resposta.Status == StatusCodes.Status201Created)
                {
                    return CreatedAtRoute(nameof(GetJogadorById), new { jogadorId = jogador.Id }, jogador);
                }

                return StatusCode(resposta.Status, resposta.Objeto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("jogador/{jogadorId}")]
        public async Task<ActionResult> EditJogador(int jogadorId, [FromBody] Jogador jogador)
        {
            try
            {
                Resposta resposta = await jogadorService.UpdateJogador(jogadorId, jogador);
                return StatusCode(resposta.Status, resposta.Objeto);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("jogador/{jogadorId}")]
        public async Task<ActionResult> DeleteJogador(int jogadorId)
        {
            try
            {
                Resposta resposta = await jogadorService.DeleteJogador(jogadorId);
                return StatusCode(resposta.Status, resposta.Objeto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
