using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AFFIFA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipesController : ControllerBase
    {
        private readonly IEquipeService equipeService;
        public EquipesController(IEquipeService equipeService)
        {
            this.equipeService = equipeService;
        }

        [HttpGet("List")]
        public async Task<ActionResult<IAsyncEnumerable<Equipe>>> ListEquipes()
        {
            try
            {
                IEnumerable<Equipe> equipes = await equipeService.GetAllEquipes();

                if(equipes.Count() == 0)
                {
                    return NotFound("Equipes não encontradas.");
                }

                return Ok(equipes);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("ListByNome/{nome}")]
        public async Task<ActionResult<IAsyncEnumerable<Equipe>>> ListEquipesByNome(string nome)
        {
            try
            {
                IEnumerable<Equipe> equipes = await equipeService.GetEquipesByNome(nome);

                if (equipes.Count() == 0)
                {
                    return NotFound("Equipes não encontradas.");
                }

                return Ok(equipes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("Get/{id}", Name = "GetEquipeById")]
        public async Task<ActionResult<Equipe>> GetEquipeById(int id)
        {
            try
            {
                Equipe equipe = await equipeService.GetEquipeById(id);

                if (equipe == null)
                {
                    return NotFound("Equipe não encontrado.");
                }

                return Ok(equipe);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateEquipe(Equipe equipe)
        {
            try
            {
                await equipeService.CreateEquipe(equipe);
                return CreatedAtRoute(nameof(GetEquipeById), new { id = equipe.Id }, equipe);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("Edit/{id}")]
        public async Task<ActionResult> EditEquipe(int id, [FromBody] Equipe equipe)
        {
            try
            {
                if (equipe.Id != id)
                {
                    return BadRequest("Erro no formato da requisição.");
                }

                await equipeService.UpdateEquipe(equipe);
                return Ok();             
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteEquipe(int id)
        {
            try
            {
                Equipe equipe = await equipeService.GetEquipeById(id);
                
                if(equipe == null)
                {
                    return NotFound("Equipe não encontrada.");                    
                }

                await equipeService.DeleteEquipe(equipe);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
