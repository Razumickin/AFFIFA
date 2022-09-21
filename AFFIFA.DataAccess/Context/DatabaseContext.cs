using AFFIFA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AFFIFA.DataAccess.Context
{
    public class DatabaseContext : DbContext
    {
        public class OptionsBuild
        {
            public DbContextOptionsBuilder optionsBuilder { get; set; }
            public DbContextOptions options { get; set; }
            private DatabaseConfiguration configuration;

            public OptionsBuild()
            {
                configuration = new DatabaseConfiguration();
                optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                optionsBuilder.UseSqlServer(configuration.ConnectionString);
                options = optionsBuilder.Options;
            }
        }
        public static OptionsBuild optionsBuild = new OptionsBuild();
        public DatabaseContext(DbContextOptions<DatabaseContext> contextOptions) : base(contextOptions) { }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Campeonato> Campeonatos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             * EQUIPE
             */
            modelBuilder.Entity<Equipe>().Property(eqp => eqp.Nome).IsRequired();
            modelBuilder.Entity<Equipe>().Property(eqp => eqp.Abreviacao).HasMaxLength(3).IsRequired();

            /*
             * JOGADOR
             */
            modelBuilder.Entity<Jogador>().Property(jgd => jgd.NomeCompleto).IsRequired();
            modelBuilder.Entity<Jogador>().Property(jgd => jgd.NomeCurto).IsRequired();
            modelBuilder.Entity<Jogador>().Property(jgd => jgd.SofifaId).IsRequired();
            modelBuilder.Entity<Jogador>().HasOne(jgd => jgd.Equipe).WithMany(eqp => eqp.Jogadores).OnDelete(DeleteBehavior.SetNull);

            /*
             * CAMPEONATO
             */
            modelBuilder.Entity<Campeonato>().Property(cmp => cmp.Nome).IsRequired();
        }
    }
}
