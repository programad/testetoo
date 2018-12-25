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

            // Infra - Data
            services.AddScoped<TestetooContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IArquivoRepository, ArquivoRepository>();

            // Application
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IArquivoAppService, ArquivoAppService>();
        }
    }
}
