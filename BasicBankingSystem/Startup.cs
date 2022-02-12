using BankCore.Interfaces;
using BankEF;
using BankEF.Repos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicBankingSystem
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddDbContext<BankDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("SqlCon"),
                   b => b.MigrationsAssembly(typeof(BankDbContext).Assembly.FullName))
                 );
            
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }       
                    
            app.UseMvc(route =>
            route.MapRoute("defualt", "{controller=Customers}/{action=Index}/{Id?}"));
            app.UseHttpsRedirection();
            app.UseStaticFiles();

          //  app.UseRouting();
           
            app.UseAuthorization();

        }
    }
}
