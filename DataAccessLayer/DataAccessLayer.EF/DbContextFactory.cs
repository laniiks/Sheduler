using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DataAccessLayer.EF
{
    public class DbContextFactory : IDesignTimeDbContextFactory<ShedulerDbContext>
    {
        /// <summary>Creates a new instance of a derived context.</summary>
        /// <param name="args"> Arguments provided by the design-time service. </param>
        /// <returns> An instance of <typeparamref name="TContext" />. </returns>
        public ShedulerDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<ShedulerDbContext>();
            //optionsBuilder.UseMySql("server=host.docker.internal; UserId=root; Password=test; database=shedulerdb;");
            optionsBuilder.UseSqlServer(config.GetConnectionString("shedulerdb"));
            return new ShedulerDbContext(optionsBuilder.Options);
        }
    }
}
