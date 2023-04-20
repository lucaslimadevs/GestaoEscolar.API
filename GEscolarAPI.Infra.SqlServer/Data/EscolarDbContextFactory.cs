using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GEscolar.API.Infra.SqlServer.Data
{
    public class EscolarDbContextFactory : IDesignTimeDbContextFactory<EscolarDbContext>
    {
        public EscolarDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EscolarDbContext>();

            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
               .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new EscolarDbContext(optionsBuilder.Options);

        }
    }
}
