using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ExamenParcialTotal.Data;
using ExamenParcialTotal.Models;
using ExamenParcialTotal.Services;
using ExamenParcialTotal.Data.DataAccess.Interfaces;
using ExamenParcialTotal.Data.DataAccess;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;

namespace ExamenParcialTotal
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddLocalization(options =>
                       options.ResourcesPath = "Resources");
            services.AddMvc();

            services.AddMvc().AddViewLocalization(
                LanguageViewLocationExpanderFormat.Suffix
                );
            services.AddAuthorization(
                options => options.AddPolicy("PermissionForSearch"
                , policy => policy.RequireRole("Supervisor", "Solicitante"))

                );

            services.AddAuthorization(
              options => options.AddPolicy("PermitirCrearSolicitud"
              , policy => policy.RequireRole("Solicitante"))

              );

            services.AddAuthorization(
              options => options.AddPolicy("PermitirVisualizarLista"
              , policy => policy.RequireRole("Supervisor"))

              );

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddTransient<IDetalleSolicitudesDA, DetalleSolicitudesDA>();
            services.AddTransient<ISolicitudesDA, SolicitudesDA>();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            var requestLocations = new RequestLocalizationOptions
            {
                //Globalization
                SupportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("es-ES")
                   
                },
                //Localization
                SupportedUICultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("es-ES")
                    
                }
            };

            app.UseRequestLocalization(requestLocations);

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715
          
            app.UseMvc(routes =>
            {
               routes.MapRoute(
               name: "MisPendientes",
               template: "MisPendientes",
               defaults: new { controller = "DetalleSolicitudes", action = "Index" });
               
                routes.MapRoute(
               name: "MisSolicitudes",
               template: "MisSolicitudes",
               defaults: new { controller = "DetalleSolicitudes", action = "IndexSolicitante" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
