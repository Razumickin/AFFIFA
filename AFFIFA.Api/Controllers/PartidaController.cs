using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AFFIFA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidaController : ControllerBase
    {
        private readonly IPartidaService partidaService;
        public PartidaController(IPartidaService partidaService)
        {
            this.partidaService = partidaService;
        }

        [HttpGet("ListByCampeonatoId/{campeonatoId}")]
        public async Task<ActionResult<IAsyncEnumerable<Partida>>> ListPartidaByCampeonatoId(int campeonatoId)
        {
            try
            {
                IEnumerable<Partida> partidas = await partidaService.GetPartidasByCampeonatoId(campeonatoId);
                return Ok(partidas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("EditGols")]
        public async Task<ActionResult> EditGols(Partida partida)
        {
            try
            {
                await partidaService.UpdatePartida(partida);
                return Ok(partida);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
