using AFFIFA.DataAccess.Context;
using AFFIFA.Domain;
using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AFFIFA.DataAccess
{
    public class EquipeRepository : EntidadeBase, IEquipeRepository
    {
        private readonly DatabaseContext databaseContext;
        public EquipeRepository()
        {
            databaseContext = new DatabaseContextFactory().CreateDbContext(new string[] { });
        }

        public async Task<Equipe.Resposta> GetAllEquipes()
        {
            try
            {
                IEnumerable<Equipe> equipes = await databaseContext.Equipes.ToListAsync();
                if (equipes.Count() < 1)
                {
                    return new Resposta(Status404NotFound, "Registros não encontrados.");
                }

                return new Resposta(Status200OK, equipes);
            }
            catch (Exception ex)
            {
                return new Resposta(Status500InternalServerError, ex.Message);
            }
        }

        public async Task<Equipe.Resposta> GetEquipesByNome(string campeonatoNome)
        {
            try
            {
                IEnumerable<Equipe> equipes = await databaseContext.Equipes.Where(eqp => eqp.Nome.Contains(campeonatoNome)).ToListAsync();
                if (equipes.Count() < 1)
                {
                    return new Resposta(Status404NotFound, campeonatoNome);
                }

                return new Resposta(Status200OK, equipes);
            }
            catch (Exception ex)
            {
                return new Resposta(Status500InternalServerError, ex.Message);
            }
        }

        public async Task<Equipe.Resposta> GetEquipeById(int equipeId)
        {
            try
            {
                Equipe equipe = await databaseContext.Equipes.FindAsync(equipeId);
                if(equipe == null)
                {
                    return new Resposta(Status404NotFound, equipeId);
                }

                return new Resposta(Status200OK, equipe);
            }
            catch (Exception ex)
            {
                return new Resposta(Status500InternalServerError, ex.Message);
            }
        }

        public async Task<Equipe.Resposta> CreateEquipe(Equipe equipe)
        {
            try
            {
                databaseContext.Equipes.Add(equipe);
                await databaseContext.SaveChangesAsync();

                return new Resposta(Status201Created, equipe);
            }
            catch (Exception ex)
            {
                return new Resposta(Status500InternalServerError, ex.Message);
            }
        }

        public async Task<Equipe.Resposta> UpdateEquipe(Equipe equipe)
        {
            try
            {
                databaseContext.Entry(equipe).State = EntityState.Modified;
                await databaseContext.SaveChangesAsync();

                return new Resposta(Status200OK, equipe);
            }
            catch (Exception ex)
            {
                return new Resposta(Status500InternalServerError, ex.Message);
            }
        }

        public async Task<Equipe.Resposta> DeleteEquipe(Equipe equipe)
        {
            try
            {
                databaseContext.Equipes.Remove(equipe);
                await databaseContext.SaveChangesAsync();

                return new Resposta(Status200OK, "");
            }
            catch (Exception ex)
            {
                return new Resposta(Status500InternalServerError, ex.Message);
            }
        }
    }
}
