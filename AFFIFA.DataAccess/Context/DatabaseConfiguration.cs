using Microsoft.Extensions.Configuration;

namespace AFFIFA.DataAccess.Context
{
    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; }
        public DatabaseConfiguration()
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), false);
            ConnectionString = configurationBuilder.Build().GetSection("ConnectionStrings:DefaultConnection").Value;
        }
    }
}
