using GEscolar.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GEscolar.API.Infra.SqlServer.Mapping
{
    public class BoletimMap : IEntityTypeConfiguration<Boletim>
    {
        public void Configure(EntityTypeBuilder<Boletim> builder)
        {
            builder.ToTable("TBLBOLETIM");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IDBOLETIM")
                .IsRequired();

            builder.Property(x => x.IdUsuario)
                .HasColumnName("IDUSUARIO")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.DataEntrega)
                .HasColumnName("DATAENTREGA")
                .IsRequired();

            builder.Property(x => x.Ativo)
                .HasColumnName("ATIVO")
                .IsRequired();

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.IdUsuario);

            builder.HasMany(x => x.NotasBoletins)
                .WithOne(d => d.Boletim)
                .HasForeignKey(x => x.IdBoletim);
        }
    }
}
