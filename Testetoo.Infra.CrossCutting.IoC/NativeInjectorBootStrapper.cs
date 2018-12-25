using Microsoft.Extensions.DependencyInjection;
using Testetoo.Application.Interfaces;
using Testetoo.Application.Services;
using Testetoo.Domain.Interfaces;
using Testetoo.Infra.Data.Context;
using Testetoo.Infra.Data.Repositories;
using Testetoo.Infra.Data.UoW;

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
