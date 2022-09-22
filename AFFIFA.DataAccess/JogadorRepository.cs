using AFFIFA.DataAccess.Context;
using AFFIFA.Domain;
using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AFFIFA.DataAccess
{
    public class JogadorRepository : EntidadeBase, IJogadorRepository
    {
        private readonly DatabaseContext databaseContext;
        public JogadorRepository()
        {
            databaseContext = new DatabaseContextFactory().CreateDbContext(new string[] { });
        }

        public async Task<IEnumerable<Jogador>> GetAllJogadores()
        {
            try
            {
                return await databaseContext.Jogadores.ToListAsync();
            }
            catch
            {

                throw;
            }
        }

        public async Task<IEnumerable<Jogador>> GetJogadoresByNome(string nome)
        {
            try
            {
                return await databaseContext.Jogadores.Where(jdg => jdg.NomeCompleto.Contains(nome) || jdg.NomeCurto.Contains(nome)).ToListAsync();
            }
            catch
            {

                throw;
            }
        }

        public async Task<Jogador> GetJogadorById(int id)
        {
            try
            {
                return await databaseContext.Jogadores.FindAsync(id);
            }
            catch
            {

                throw;
            }
        }

        public async Task CreateJogador(Jogador jogador)
        {
            try
            {
                databaseContext.Jogadores.Add(jogador);
                await databaseContext.SaveChangesAsync();
            }
            catch
            {

                throw;
            }
        }

        public async Task UpdateJogador(Jogador jogador)
        {
            try
            {
                databaseContext.Entry(jogador).State = EntityState.Modified;
                await databaseContext.SaveChangesAsync();
            }
            catch
            {

                throw;
            }
        }

        public async Task DeleteJogador(Jogador jogador)
        {
            try
            {
                databaseContext.Jogadores.Remove(jogador);
                await databaseContext.SaveChangesAsync();
            }
            catch
            {

                throw;
            }
        }        
    }
}
