using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApplication3.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces.Business;
using WebApplication1.Business.Business;
using WebApplication1.Interfaces.Repositories;
using WebApplication1.Repositories.Repositories;

namespace WebApplication3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors();
            DependencyInjectionServicos(services);
            DependencyInjectionRepositorios(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:3000").AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());


            app.UseHttpsRedirection();
            app.UseMvc();
        }

        public void DependencyInjectionServicos(IServiceCollection services)
        {
            services.AddScoped<IRecipesBusiness, RecipeBusiness>();
        }

        public void DependencyInjectionRepositorios(IServiceCollection services)
        {
            services.AddScoped<IRecipeRepository, RecipeRepository>();
        }
    }
}
