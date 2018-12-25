using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Testetoo.Domain.Models;

namespace Testetoo.Infra.Data.Configurations
{
    public class ArquivoConfig : IEntityTypeConfiguration<Arquivo>
    {
        public void Configure(EntityTypeBuilder<Arquivo> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Nome)
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .HasDefaultValueSql("getdate()");
        }
    }
}
