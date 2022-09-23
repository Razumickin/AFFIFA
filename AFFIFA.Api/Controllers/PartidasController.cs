using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static AFFIFA.Domain.EntidadeBase;

namespace AFFIFA.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PartidasController : ControllerBase
    {
        private readonly IPartidaService partidaService;
        public PartidasController(IPartidaService partidaService)
        {
            this.partidaService = partidaService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Partida>>> ListPartidaByCampeonatoId([FromBody] int campeonatoId)
        {
            try
            {
                Resposta resposta = await partidaService.GetPartidasByCampeonatoId(campeonatoId);
                return StatusCode(resposta.Status, resposta.Objeto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> EditGols([FromBody] Partida partida)
        {
            try
            {
                Resposta resposta = await partidaService.UpdatePartida(partida);
                return StatusCode(resposta.Status, resposta.Objeto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
