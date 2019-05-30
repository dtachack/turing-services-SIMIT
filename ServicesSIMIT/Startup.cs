using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicesSIMIT.DI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Utilities.Library.Const;
using UtilitiesLibrary.Models;


namespace ServicesSIMIT
{
    /// <summary>
    /// Startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ServicesSIMIT.Startup"/> class.
        /// </summary>
        /// <param name="configuration">Configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddCors(opt =>
            {
                opt.AddPolicy("Default_CorsPolicy", o =>
                {
                    o.AllowAnyHeader();
                    o.AllowAnyMethod();
                    o.AllowAnyOrigin();
                });
            });
            services.AddMvc()
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "SIMIT Services",
                    Version = "v1",
                    Description = "Aplicación de servicios proyecto SIMIT",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact
                    {
                        Name = "Turing",
                        Email = "ds-nino@javeriana.edu.co",
                        Url = "https://www.javeriana.edu.co"
                    }
                });
                //Agregando comentarios Xml a la documentación
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //Cargamos la cadena de conexión

            var dbSettingsWrite = new DbSettings();
            Configuration.Bind("DbSettingWrite", dbSettingsWrite);
            


            var dbSettingsRead = new DbSettings();
            Configuration.Bind("DbSettingRead", dbSettingsRead);

            List<DbSettings> dbSettings = new List<DbSettings>();
            dbSettings.Add(dbSettingsRead);
            dbSettings.Add(dbSettingsWrite);
            services.AddSingleton(dbSettings);

            

            services.AddHttpContextAccessor();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            DependencyInjectionProfile.RegisterProfile(services);
        }

      /// <summary>
      /// Configure the specified app and env.
      /// </summary>
      /// <param name="app">App.</param>
      /// <param name="env">Env.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            //Obtenemos el nombre de la aplicación URL
            string appNameURI = Configuration.GetValue<string>("AppNameURI")?.Trim() ?? "/";
            appNameURI = (!appNameURI.StartsWith("/") ? ("/" + appNameURI) : appNameURI);
            appNameURI = (!appNameURI.EndsWith("/") ? (appNameURI + "/") : appNameURI);

            //Hacemos disponible el contenedor de dependencias
            Globals.ServiceProvider = app.ApplicationServices;

            string swaggerEndPoint = $"{appNameURI}swagger/v1/swagger.json";

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("Default_CorsPolicy");
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.RoutePrefix = "api";
                s.SwaggerEndpoint(swaggerEndPoint, "SIMIT Services");
            });
        }
    }
}
