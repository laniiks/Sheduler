using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataAccessLayer.EF
{
    public static class DbContextInstaller
    {
        public static void ConfigureDbContext(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //services
            //    .AddDbContext<ShedulerDbContext>(o => o
            //        .UseLazyLoadingProxies()
            //        .UseMySql("server=host.docker.internal; UserId=root; Password=test; database=shedulerdb;"));
            services
                .AddDbContext<ShedulerDbContext>(o => o
                    .UseLazyLoadingProxies()
                    .UseSqlServer(config.GetConnectionString("shedulerdb")));
        }
    }
}
