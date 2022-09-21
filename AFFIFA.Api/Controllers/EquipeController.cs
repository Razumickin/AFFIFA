using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AFFIFA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipeController : ControllerBase
    {
        private readonly IEquipeService equipeService;
        public EquipeController(IEquipeService equipeService)
        {
            this.equipeService = equipeService;
        }

        [HttpGet("List")]
        public async Task<ActionResult<IAsyncEnumerable<Equipe>>> GetEquipes()
        {
            try
            {
                IEnumerable<Equipe> equipes = await equipeService.ListEquipes();

                if(equipes.Count() == 0)
                {
                    return NotFound("Não há equipes registradas.");
                }

                return Ok(equipes);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("ListByNome/{nome}")]
        public async Task<ActionResult<IAsyncEnumerable<Equipe>>> GetEquipes(string nome)
        {
            try
            {
                IEnumerable<Equipe> equipes = await equipeService.ListEquipesByNome(nome);

                if (equipes.Count() == 0)
                {
                    return NotFound($"Não há equipes registradas com o critério '{nome}'.");
                }

                return Ok(equipes);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao listar equipes.");
            }
        }

        [HttpGet("Get/{id}", Name = "GetEquipe")]
        public async Task<ActionResult<Equipe>> GetEquipe(int id)
        {
            try
            {
                Equipe equipe = await equipeService.GetEquipe(id);

                return Ok(equipe);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao listar equipes.");
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateEquipe(Equipe equipe)
        {
            try
            {
                await equipeService.CreateEquipe(equipe);
                return CreatedAtRoute(nameof(GetEquipe), new { id = equipe.Id }, equipe);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao cadastrar a equipe.");
            }
        }

        [HttpPut("Edit/{id}")]
        public async Task<ActionResult> UpdateEquipe(int id, [FromBody] Equipe equipe)
        {
            try
            {
                if (equipe.Id == id)
                {
                    await equipeService.UpdateEquipe(equipe);
                    return NoContent();
                }

                return BadRequest("Erro no formato da requisição.");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao editar a equipe.");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteEquipe(int id)
        {
            try
            {
                Equipe equipe = await equipeService.GetEquipe(id);
                
                if(equipe != null)
                {
                    await equipeService.DeleteEquipe(equipe);   
                    return Ok();
                }

                return NotFound("Equipe não encontrada.");
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao editar a equipe.");
            }
        }
    }
}
