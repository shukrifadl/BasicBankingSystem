using BankEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicBankingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var webHost= CreateHostBuilder(args).Build();
            RunMigrations(webHost);
            webHost.Run();
        }

        private static void RunMigrations(IHost webHost)
        {
            using (var scope= webHost.Services.CreateScope())
            {
               var db= scope.ServiceProvider.GetRequiredService<BankDbContext>();
                db.Database.Migrate();
            }
                throw new NotImplementedException();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
