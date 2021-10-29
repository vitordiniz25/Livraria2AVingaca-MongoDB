using ElmahCore;
using ElmahCore.Mvc;
using LivrariaComMongo.Api.Middlewares;
using LivrariaComMongo.Domain.Handlers;
using LivrariaComMongo.Domain.Interfaces.Repositories;
using LivrariaComMongo.Infra.Data.DataContexts;
using LivrariaComMongo.Infra.Data.Repositories;
using LivrariaComMongo.Infra.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace LivrariaComMongo.Api
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
            #region AppSettings

            AppSettings appSettings = new();
            Configuration.GetSection("AppSettings").Bind(appSettings);
            services.AddSingleton(appSettings);

            #endregion

            #region Elmah

            services.AddElmah();
            services.AddElmah<XmlFileErrorLog>(opt =>
            {
                opt.LogPath = "~/log";
            });

            #endregion

            #region DataContexts

            services.AddScoped<DataContext>();

            #endregion

            #region Repositories

            services.AddTransient<ILivroRepository, LivroRepository>();

            #endregion

            #region Handlers

            services.AddTransient<LivroHandler, LivroHandler>();

            #endregion

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LivrariaComLog.Api", Version = "v1" });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LivrariaComLog.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseElmah();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
