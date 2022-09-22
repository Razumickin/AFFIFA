using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static AFFIFA.Domain.EntidadeBase;

namespace AFFIFA.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CampeonatosController : ControllerBase
    {
        private readonly ICampeonatoService campeonatoService;
        public CampeonatosController(ICampeonatoService campeonatoService)
        {
            this.campeonatoService = campeonatoService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Campeonato>>> ListCampeonatos()
        {
            try
            {
                Resposta resposta = await campeonatoService.GetAllCampeonatos();
                return StatusCode(resposta.Status, resposta.Objeto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{campeonatoNome:alpha}")]
        public async Task<ActionResult<IEnumerable<Campeonato>>> ListCampeonatosByNome(string campeonatoNome)
        {
            try
            {               
                Resposta resposta = await campeonatoService.GetCampeonatosByNome(campeonatoNome);
                return StatusCode(resposta.Status, resposta.Objeto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{campeonatoId:int}", Name = "GetCampeonatoById")]
        public async Task<ActionResult<Campeonato>> GetCampeonatoById(int campeonatoId)
        {
            try
            {
                Resposta resposta = await campeonatoService.GetCampeonatoById(campeonatoId);
                return StatusCode(resposta.Status, resposta.Objeto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateCampeonato(Campeonato campeonato)
        {
            try
            {
                Resposta resposta = await campeonatoService.CreateCampeonato(campeonato);
                if(resposta.Status == StatusCodes.Status201Created)
                {
                    return CreatedAtRoute(nameof(GetCampeonatoById), new { campeonatoId = campeonato.Id }, campeonato);
                }

                return StatusCode(resposta.Status, resposta.Objeto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }        

        [HttpPut("campeonato/{campeonatoId}")]
        public async Task<ActionResult> EditCampeonato(int campeonatoId, [FromBody] Campeonato campeonato)
        {
            try
            {
                Resposta resposta = await campeonatoService.UpdateCampeonato(campeonatoId, campeonato);
                return StatusCode(resposta.Status, resposta.Objeto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{campeonatoId}")]
        public async Task<ActionResult> DeleteCampeonato(int campeonatoId)
        {
            try
            {
                Resposta resposta = await campeonatoService.DeleteCampeonato(campeonatoId);
                return StatusCode(resposta.Status, resposta.Objeto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("campeonato/{campeonatoId}/equipes")]
        public async Task<ActionResult> AddEquipesCampeonato(int campeonatoId, [FromBody] int equipeId)
        {
            try
            {
                await campeonatoService.CreateCampeonatoEquipe(campeonatoId, equipeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
