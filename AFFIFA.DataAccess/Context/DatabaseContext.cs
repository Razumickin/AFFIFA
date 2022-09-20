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
    }
}
