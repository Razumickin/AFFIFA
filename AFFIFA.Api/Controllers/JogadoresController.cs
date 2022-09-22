using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AFFIFA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadoresController : ControllerBase
    {
        private readonly IJogadorService jogadorService;
        public JogadoresController(IJogadorService jogadorService)
        {
            this.jogadorService = jogadorService;
        }

        [HttpGet("List")]
        public async Task<ActionResult<IAsyncEnumerable<Jogador>>> ListJogadores()
        {
            try
            {
                IEnumerable<Jogador> jogadores = await jogadorService.GetAllJogadores();

                if(jogadores.Count() == 0)
                {
                    return NotFound("Jogadores não encontrados.");
                }

                return Ok(jogadores);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("ListByNome/{nome}")]
        public async Task<ActionResult<IAsyncEnumerable<Jogador>>> ListJogadoresByNome(string nome)
        {
            try
            {
                IEnumerable<Jogador> jogadores = await jogadorService.GetJogadoresByNome(nome);

                if (jogadores.Count() == 0)
                {
                    return NotFound("Jogadores não encontrados.");
                }

                return Ok(jogadores);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("Get/{id}", Name = "GetJogadorById")]
        public async Task<ActionResult<Jogador>> GetJogadorById(int id)
        {
            try
            {
                Jogador jogador = await jogadorService.GetJogadorById(id);

                if (jogador == null)
                {
                    return NotFound("Jogador não encontrado.");
                }

                return Ok(jogador);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateJogador(Jogador jogador)
        {
            try
            {
                await jogadorService.CreateJogador(jogador);
                return CreatedAtRoute(nameof(GetJogadorById), new { id = jogador.Id }, jogador);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("Edit/{id}")]
        public async Task<ActionResult> EditJogador(int id, [FromBody] Jogador jogador)
        {
            try
            {
                if(jogador.Id != id)
                {
                    return BadRequest("Erro no formato da requisição.");
                }

                await jogadorService.UpdateJogador(jogador);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteJogador(int id)
        {
            try
            {
                Jogador jogador = await jogadorService.GetJogadorById(id);

                if(jogador == null)
                {
                    return NotFound("Jogador não encontrado.");
                }

                await jogadorService.DeleteJogador(jogador);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
