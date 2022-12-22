using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestWithASP_NET5Udemy.Business;
using RestWithASP_NET5Udemy.Business.Implementation;
using RestWithASP_NET5Udemy.Model.Context;
using RestWithASP_NET5Udemy.Repository;
using RestWithASP_NET5Udemy.Repository.Implementation;
using Serilog;
using System;
using System.Collections.Generic;

namespace RestWithASP_NET5Udemy
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Conexão banco de dados
            var conection = Configuration["MySQLConection:MySQLConectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(conection));

            if (Environment.IsDevelopment())
            {
                MigrationDatabase(conection);
            }

            //Versionamento API
            services.AddApiVersioning();

            //Injeção de Dependencia
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            services.AddScoped<IBookBussiness, BookBusinessImplementation>();

            services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();
            services.AddScoped<IBookRepository, BookRepositoryImplementation>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void MigrationDatabase(string conection)
        {
            try
            {
                var evolveConection = new MySql.Data.MySqlClient.MySqlConnection(conection);
                var evolve = new EvolveDb.Evolve(evolveConection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migration", "db/dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error("Database Migration failed: " + ex);
            }
        }

    }
}
