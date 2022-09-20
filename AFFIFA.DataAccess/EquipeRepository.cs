using AFFIFA.DataAccess.Context;
using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AFFIFA.DataAccess
{
    public class EquipeRepository : IEquipeRepository
    {
        private readonly DatabaseContext databaseContext;
        public EquipeRepository()
        {
            this.databaseContext = new DatabaseContextFactory().CreateDbContext(new string[] { });
        }

        public async Task<IEnumerable<Equipe>> GetEquipes()
        {
            try
            {
                return await databaseContext.Equipes.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Equipe>> GetEquipes(string nome)
        {
            try
            {
                return await databaseContext.Equipes.Where(e => e.Nome.Contains(nome)).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Equipe> GetEquipe(int id)
        {
            try
            {
                return await databaseContext.Equipes.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateEquipe(Equipe equipe)
        {
            try
            {
                databaseContext.Equipes.Add(equipe);
                await databaseContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateEquipe(Equipe equipe)
        {
            try
            {
                databaseContext.Entry(equipe).State = EntityState.Modified;
                await databaseContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteEquipe(Equipe equipe)
        {
            try
            {
                databaseContext.Equipes.Remove(equipe);
                await databaseContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
