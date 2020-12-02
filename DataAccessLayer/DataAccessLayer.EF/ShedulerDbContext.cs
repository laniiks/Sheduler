using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EF
{
    public class ShedulerDbContext: DbContext
    {
        public ShedulerDbContext(DbContextOptions<ShedulerDbContext> options): base(options) { }

        public DbSet<Tasks> Tasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseMySql("server=host.docker.internal; UserId=root; Password=test; database=shedulerdb");
            //}
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=shedulerdb;Trusted_Connection=True");
        }
    }
}
