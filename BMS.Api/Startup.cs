using BMS.Domain.Commands;
using BMS.Domain.Handlers;
using BMS.Domain.Repositories.Interfaces;
using BMS.Infra.Contexts;
using BMS.Infra.Repositories;
using BMS.Shared.Handlers.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BMS.Api
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
            services.AddControllers();

            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));

            services.AddTransient<IRepository, Repository>();
            services.AddTransient<IHandler<CadastraProdutoCommand>, CadastraProdutoHandler>();
            services.AddTransient<IHandler<CriaUsuarioCommand>, CriaUsuarioHandler>();
            services.AddTransient<IHandler<GeraVendaCommand>, GeraVendaHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();


            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
