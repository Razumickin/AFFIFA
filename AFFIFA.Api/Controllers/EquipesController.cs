using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static AFFIFA.Domain.EntidadeBase;

namespace AFFIFA.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class EquipesController : ControllerBase
    {
        private readonly IEquipeService equipeService;
        public EquipesController(IEquipeService equipeService)
        {
            this.equipeService = equipeService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Equipe>>> ListEquipes()
        {
            try
            {
                Resposta resposta = await equipeService.GetAllEquipes();
                return StatusCode(resposta.Status, resposta.Objeto);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{equipeNome:alpha}")]
        public async Task<ActionResult<IAsyncEnumerable<Equipe>>> ListEquipesByNome(string equipeNome)
        {
            try
            {
                Resposta resposta = await equipeService.GetEquipesByNome(equipeNome);
                return StatusCode(resposta.Status, resposta.Objeto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("equipe/{equipeId:int}", Name = "GetEquipeById")]
        public async Task<ActionResult<Equipe>> GetEquipeById(int equipeId)
        {
            try
            {
                Resposta resposta = await equipeService.GetEquipeById(equipeId);
                return StatusCode(resposta.Status, resposta.Objeto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateEquipe(Equipe equipe)
        {
            try
            {
                Resposta resposta = await equipeService.CreateEquipe(equipe);
                if(resposta.Status == StatusCodes.Status201Created)
                {
                    return CreatedAtRoute(nameof(GetEquipeById), new { equipeId = equipe.Id }, equipe);
                }

                return StatusCode(resposta.Status, resposta.Objeto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("equipe/{equipeId}")]
        public async Task<ActionResult> EditEquipe(int equipeId, [FromBody] Equipe equipe)
        {
            try
            {
                Resposta resposta = await equipeService.UpdateEquipe(equipeId, equipe);
                return StatusCode(resposta.Status, resposta.Objeto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("equipe/{equipeId}")]
        public async Task<ActionResult> DeleteEquipe(int equipeId)
        {
            try
            {
                Resposta resposta = await equipeService.DeleteEquipe(equipeId);
                return StatusCode(resposta.Status, resposta.Objeto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
