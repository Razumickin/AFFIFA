using AFFIFA.DataAccess.Context;
using AFFIFA.Domain;
using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AFFIFA.DataAccess
{
    public class PartidaRepository : EntidadeBase, IPartidaRepository
    {
        private readonly DatabaseContext databaseContext;
        public PartidaRepository()
        {
            databaseContext = new DatabaseContextFactory().CreateDbContext(new string[] { });
        }
        public async Task<Resposta> GetPartidasByCampeonatoId(int campeonatoId)
        {
            try
            {
                IEnumerable<Partida> partidas = await databaseContext.Partidas.Where(ptd => ptd.Campeonato.Id == campeonatoId).ToListAsync();
                if (partidas.Count() < 1)
                {
                    return new Resposta(Status404NotFound, campeonatoId);
                }

                return new Resposta(Status200OK, partidas);
            }
            catch (Exception ex)
            {
                return new Resposta(Status500InternalServerError, ex.Message);
            }
        }

        public async Task<Resposta> CreatePartida(Partida partida)
        {
            try
            {
                databaseContext.Partidas.Add(partida);
                await databaseContext.SaveChangesAsync();

                return new Resposta(Status201Created, partida);
            }
            catch (Exception ex)
            {
                return new Resposta(Status500InternalServerError, ex.Message);
            }
        }

        public async Task<Resposta> UpdatePartida(Partida partida)
        {
            try
            {
                databaseContext.Entry(partida).State = EntityState.Modified;
                await databaseContext.SaveChangesAsync();

                return new Resposta(Status200OK, partida);
            }
            catch (Exception ex)
            {
                return new Resposta(Status500InternalServerError, ex.Message);
            }
        }        
    }
}
