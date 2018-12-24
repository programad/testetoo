
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Testetoo.Application.Interfaces;
using Testetoo.Application.Services;
using Testetoo.Domain.Interfaces;
using TesteToo.Infra.Data.Context;
using TesteToo.Infra.Data.Repositories;
using TesteToo.Infra.Data.UoW;

namespace Testetoo.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();

            // Infra - Data
            services.AddScoped<TestetooContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
