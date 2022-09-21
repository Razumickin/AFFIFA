using AFFIFA.DataAccess.Context;
using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AFFIFA.DataAccess
{
    public class CampeonatoRepository : ICampeonatoRepository
    {
        private readonly DatabaseContext databaseContext;
        public CampeonatoRepository()
        {
            databaseContext = new DatabaseContextFactory().CreateDbContext(new string[] { });
        }

        public async Task<IEnumerable<Campeonato>> GetAllCampeonatos()
        {
            try
            {
                return await databaseContext.Campeonatos.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Campeonato>> GetCampeonatosByNome(string nome)
        {
            try
            {
                return await databaseContext.Campeonatos.Where(cmp => cmp.Nome.Contains(nome)).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Campeonato> GetCampeonatoById(int id)
        {
            try
            {
                return await databaseContext.Campeonatos.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateCampeonato(Campeonato campeonato)
        {
            try
            {
                databaseContext.Campeonatos.Add(campeonato);
                await databaseContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateCampeonato(Campeonato campeonato)
        {
            try
            {
                databaseContext.Entry(campeonato).State = EntityState.Modified;
                await databaseContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteCampeonato(Campeonato campeonato)
        {
            try
            {
                databaseContext.Campeonatos.Remove(campeonato);
                await databaseContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
