using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace ContasApplication.Data
{
    public class BankContextFactory : IDesignTimeDbContextFactory<BankContext>
    {

        public BankContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<BankContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgresConnection"));

            return new BankContext(optionsBuilder.Options);
        }
    }
}
