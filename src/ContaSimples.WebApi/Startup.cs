
using ContaSimples.BusinessCore.Interfaces;
using ContaSimples.BusinessCore.Repositories;
using ContaSimples.BusinessCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ContaSimples.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);


            services.AddControllers();

            services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IContaCorrenteService, ContaCorrenteService>();
            services.AddScoped<ITransacoesService, TransacoesService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddDbContext<ContaCorrenteContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Conta Simples", Version = "v1" });

            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseRouting();

            app.UseCors(x => x
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        );

            app.UseHttpsRedirection();

            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Conta Simples");
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
