using GEscolar.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GEscolar.API.Infra.SqlServer.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("AspNetUsers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.DataNascimento)
                .HasColumnName("DataNascimento")
                .IsRequired();

            builder.Property(x => x.Tipo)
                .HasColumnName("Tipo")
                .IsRequired();
        }
    }
}
