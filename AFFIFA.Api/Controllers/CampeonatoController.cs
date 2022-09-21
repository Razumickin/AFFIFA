using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AFFIFA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonatoController : ControllerBase
    {
        private readonly ICampeonatoService campeonatoService;
        public CampeonatoController(ICampeonatoService campeonatoService)
        {
            this.campeonatoService = campeonatoService;
        }

        [HttpGet("List")]
        public async Task<ActionResult<IAsyncEnumerable<Campeonato>>> ListCampeonatos()
        {
            try
            {
                IEnumerable<Campeonato> campeonatos = await campeonatoService.GetAllCampeonatos();

                if (campeonatos.Count() == 0)
                {
                    return NotFound("Campeonatos não encontrados.");
                }

                return Ok(campeonatos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("ListByNome/{nome}")]
        public async Task<ActionResult<IEnumerable<Campeonato>>> ListCampeonatosByNome(string nome)
        {
            try
            {
                IEnumerable<Campeonato> campeonatos = await campeonatoService.GetCampeonatosByNome(nome);

                if (campeonatos.Count() == 0)
                {
                    return NotFound("Campeonatos não encontrados.");
                }

                return Ok(campeonatos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("Get/{id}", Name = "GetCampeonatoById")]
        public async Task<ActionResult<Campeonato>> GetCampeonatoById(int id)
        {
            try
            {
                Campeonato campeonato = await campeonatoService.GetCampeonatoById(id);

                if (campeonato == null)
                {
                    return NotFound("Campeonato não encontrado.");
                }

                return Ok(campeonato);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateCampeonato(Campeonato campeonato)
        {
            try
            {
                await campeonatoService.CreateCampeonato(campeonato);
                return CreatedAtRoute(nameof(GetCampeonatoById), new { id = campeonato.Id }, campeonato);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("Edit/{id}")]
        public async Task<ActionResult> EditCampeonato(int id, [FromBody] Campeonato campeonato)
        {
            try
            {
                if (campeonato.Id != id)
                {
                    return BadRequest("Erro no formato da requisição");
                }

                await campeonatoService.UpdateCampeonato(campeonato);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteCampeonato(int id)
        {
            try
            {
                Campeonato campeonato = await campeonatoService.GetCampeonatoById(id);
                if (campeonato == null)
                {
                    return NotFound("Campeonato não encontrado.");
                }

                await campeonatoService.DeleteCampeonato(campeonato);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
