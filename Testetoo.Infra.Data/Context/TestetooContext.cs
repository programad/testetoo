using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Testetoo.Domain.Models;
using Testetoo.Infra.Data.Configurations;

namespace Testetoo.Infra.Data.Context
{
    public class TestetooContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Arquivo> Arquivos { get; set; }

        public TestetooContext()
        {

        }

        public TestetooContext(DbContextOptions<TestetooContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new ArquivoConfig());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();


            var configuration = builder.Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Testetoo.Infra.Data"));
        }
    }
}
