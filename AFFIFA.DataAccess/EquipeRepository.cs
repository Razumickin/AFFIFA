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

        public async Task<IEnumerable<Equipe>> GetAllEquipes()
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

        public async Task<IEnumerable<Equipe>> GetEquipesByNome(string nome)
        {
            try
            {
                return await databaseContext.Equipes.Where(eqp => eqp.Nome.Contains(nome)).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Equipe> GetEquipeById(int id)
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
