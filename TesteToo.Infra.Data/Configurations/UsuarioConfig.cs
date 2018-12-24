using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Testetoo.Domain.Models;

namespace TesteToo.Infra.Data.Configurations
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Nome)
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(c => c.UserName)
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(c => c.Senha)
                .IsRequired();

            builder.Property(c => c.DataNascimento)
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .HasDefaultValueSql("getdate()");
        }
    }
}
