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
        public async Task<IEnumerable<Partida>> GetPartidasByCampeonatoId(int campeonatoId)
        {
            try
            {
                return await databaseContext.Partidas.Where(ptd => ptd.Campeonato.Id == campeonatoId).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task CreatePartida(Partida partida)
        {
            try
            {
                databaseContext.Partidas.Add(partida);
                await databaseContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdatePartida(Partida partida)
        {
            try
            {
                databaseContext.Entry(partida).State = EntityState.Modified;
                await databaseContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }        
    }
}
