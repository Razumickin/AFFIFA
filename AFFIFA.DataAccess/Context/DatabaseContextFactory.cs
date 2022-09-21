using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AFFIFA.DataAccess.Context
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            DatabaseConfiguration databaseConfiguration = new DatabaseConfiguration();
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlServer(databaseConfiguration.ConnectionString);

            return new DatabaseContext((DbContextOptions<DatabaseContext>)optionsBuilder.Options);
        }
    }
}
