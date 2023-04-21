using GEscolar.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GEscolar.API.Infra.SqlServer.Mapping
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("TBLTURMA");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IDTURMA")
                .IsRequired();

            builder.Property(x => x.IdDisciplina)
                .HasColumnName("IDDISCIPLINA")                
                .IsRequired();

            builder.Property(x => x.IdUsuario)
                .HasColumnName("IDUSUARIO")
                .IsRequired();

            builder.Property(x => x.Ativo)
                .HasColumnName("ATIVO")
                .IsRequired();

            builder.HasOne(x => x.Disciplina)
                .WithMany(d => d.Turmas)
                .HasForeignKey(x => x.IdDisciplina);

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.IdUsuario);
        }
    }
}
