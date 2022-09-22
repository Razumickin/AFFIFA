using AFFIFA.DataAccess.Context;
using AFFIFA.Domain;
using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AFFIFA.DataAccess
{
    public class CampeonatoRepository : EntidadeBase, ICampeonatoRepository
    {
        private readonly DatabaseContext databaseContext;
        public CampeonatoRepository()
        {
            databaseContext = new DatabaseContextFactory().CreateDbContext(new string[] { });
        }

        public async Task<Resposta> GetAllCampeonatos()
        {
            try
            {
                IEnumerable<Campeonato> campeonatos = await databaseContext.Campeonatos.ToListAsync();
                if (campeonatos.Count() < 1)
                {
                    return new Resposta(Status404NotFound, "Registros não encontrados.");                    
                }

                return new Resposta(Status200OK, campeonatos);
            }
            catch (Exception ex)
            {
                return new Resposta(Status500InternalServerError, ex.Message);
            }
        }

        public async Task<Resposta> GetCampeonatosByNome(string campeonatoNome)
        {            
            try
            {
                IEnumerable<Campeonato> campeonatos = await databaseContext.Campeonatos.Where(cmp => cmp.Nome.Contains(campeonatoNome)).ToListAsync();
                if (campeonatos.Count() < 1)
                {                    
                    return new Resposta(Status404NotFound, campeonatoNome);
                }

                return new Resposta(Status200OK, campeonatos);
            }
            catch (Exception ex)
            {
                return new Resposta(Status500InternalServerError, ex.Message);
            }
        }

        public async Task<Resposta> GetCampeonatoById(int campeonatoId)
        {
            try
            {
                Campeonato campeonato = await databaseContext.Campeonatos.FindAsync(campeonatoId);
                if (campeonato == null)
                {
                    return new Resposta(Status404NotFound, campeonatoId);                    
                }

                return new Resposta(Status200OK, campeonato);
            }
            catch (Exception ex)
            {
                return new Resposta(Status500InternalServerError, ex.Message);
            }
        }

        public async Task<Resposta> CreateCampeonato(Campeonato campeonato)
        {
            try
            {
                databaseContext.Campeonatos.Add(campeonato);
                await databaseContext.SaveChangesAsync();

                return new Resposta(Status201Created, campeonato);
            }
            catch (Exception ex)
            {
                return new Resposta(Status500InternalServerError, ex.Message);
            }
        }

        public async Task<Resposta> UpdateCampeonato(Campeonato campeonato)
        {
            try
            {
                databaseContext.Entry(campeonato).State = EntityState.Modified;
                await databaseContext.SaveChangesAsync();

                return new Resposta(Status200OK, campeonato);
            }
            catch (Exception ex)
            {
                return new Resposta(Status500InternalServerError, ex.Message);
            }
        }

        public async Task<Resposta> DeleteCampeonato(Campeonato campeonato)
        {
            try
            {
                databaseContext.Campeonatos.Remove(campeonato);
                await databaseContext.SaveChangesAsync();

                return new Resposta(Status200OK, "");
            }
            catch (Exception ex)
            {
                return new Resposta(Status500InternalServerError, ex.Message);
            }
        }

        public async Task<Resposta> CreateCampeonatoEquipe(Campeonato campeonato, Equipe equipe)
        {           
            return new Resposta(Status500InternalServerError, "");
        }
    }
}
