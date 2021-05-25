 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeNivel.Business;
using ControleDeNivel.Business.Services;
using ControleDeNivel.Data;
using ControleDeNivel.Data.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ControleDeNivel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(
                //config =>
                //    {   //Filtro de usuarios
                //        config.Filters.Add(new UserFilter());
                //    }
                    ).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader().AllowAnyOrigin()
                    .AllowCredentials();
            }));
            services.AddDbContext<Context>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("DB_ControleDeNivel"),// UseMySql UseSqlServer
                  b => b.MigrationsAssembly("ControleDeNivel")));
            services.AddSession();
            //Project .Data
            services.AddTransient<DeviceInfoDao>();
            services.AddTransient<LogFalhasDao>();
            services.AddTransient<MensagensDao>();
            services.AddTransient<SinaisDao>();
            services.AddTransient<SinalDeInputDao>();
            //services.AddTransient<LoginDao>();
            //Project .Business
            services.AddTransient<DevicesInfo>();
            services.AddTransient<LogsFalha>();
            services.AddTransient<Mensagens>();
            services.AddTransient<Signals>();
            services.AddTransient<SinaisDeInput>();
            //services.AddTransient<Login>();
        }

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
            app.UseCors("MyPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
