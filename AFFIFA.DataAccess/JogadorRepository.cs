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

        public async Task<Resposta> GetAllJogadores()
        {
            try
            {
                IEnumerable<Jogador> jogadores = await databaseContext.Jogadores.ToListAsync();
                if(jogadores.Count() < 1)
                {
                    return new Resposta(Status404NotFound, "Registros não encontrados.");
                }

                return new Resposta(Status200OK, jogadores);
            }
            catch (Exception ex)
            {
                return new Resposta(Status500InternalServerError, ex.Message);
            }
        }

        public async Task<Resposta> GetJogadoresByNome(string jogadorNome)
        {
            try
            {
                IEnumerable<Jogador> jogadores = await databaseContext.Jogadores.Where(jdg => jdg.NomeCompleto.Contains(jogadorNome) || jdg.NomeCurto.Contains(jogadorNome)).ToListAsync();
                if (jogadores.Count() < 1)
                {
                    return new Resposta(Status404NotFound, jogadorNome);
                }

                return new Resposta(Status200OK, jogadores);
            }
            catch (Exception ex)
            {
                return new Resposta(Status500InternalServerError, ex.Message);
            }
        }

        public async Task<Resposta> GetJogadorById(int jogadorId)
        {
            try
            {
                Jogador jogador = await databaseContext.Jogadores.FindAsync(jogadorId);
                if(jogador == null)
                {
                    return new Resposta(Status404NotFound, jogadorId);
                }

                return new Resposta(Status200OK, jogador);
            }
            catch (Exception ex)
            {
                return new Resposta(Status500InternalServerError, ex.Message);
            }
        }

        public async Task<Resposta> CreateJogador(Jogador jogador)
        {
            try
            {
                databaseContext.Jogadores.Add(jogador);
                await databaseContext.SaveChangesAsync();

                return new Resposta(Status201Created, jogador);
            }
            catch (Exception ex)
            {
                return new Resposta(Status500InternalServerError, ex.Message);
            }
        }

        public async Task<Resposta> UpdateJogador(Jogador jogador)
        {
            try
            {
                databaseContext.Entry(jogador).State = EntityState.Modified;
                await databaseContext.SaveChangesAsync();

                return new Resposta(Status200OK, jogador);
            }
            catch (Exception ex)
            {
                return new Resposta(Status500InternalServerError, ex.Message);
            }
        }

        public async Task<Resposta> DeleteJogador(Jogador jogador)
        {
            try
            {
                databaseContext.Jogadores.Remove(jogador);
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
