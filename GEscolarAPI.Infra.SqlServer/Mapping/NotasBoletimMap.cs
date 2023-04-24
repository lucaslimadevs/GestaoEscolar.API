using GEscolar.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace GEscolar.API.Infra.SqlServer.Mapping
{
    public class NotasBoletimMap : IEntityTypeConfiguration<NotasBoletim>
    {
        public void Configure(EntityTypeBuilder<NotasBoletim> builder)
        {
            builder.ToTable("TBLNOTASBOLETIM");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IDNOTASBOLETIM")
                .IsRequired();

            builder.Property(x => x.IdTurma)
                .HasColumnName("IDTURMA")                
                .IsRequired();

            builder.Property(x => x.IdBoletim)
                .HasColumnName("IDBOLETIM")
                .IsRequired();

            builder.Property(x => x.Nota)
                .HasColumnName("NOTA")
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(x => x.Ativo)
                .HasColumnName("ATIVO")
                .IsRequired();

            builder.HasOne(x => x.Turma)
                .WithMany(d => d.NotasBoletins)
                .HasForeignKey(x => x.IdTurma)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.Boletim)
                .WithMany(d => d.NotasBoletins)
                .HasForeignKey(x => x.IdBoletim);
        }
    }
}
