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

            builder.Property(x => x.IdProfessor)
                .HasColumnName("IDPROFESSOR")                
                .IsRequired();

            builder.Property(x => x.IdAluno)
                .HasColumnName("IDALUNO")
                .IsRequired();

            builder.Property(x => x.Ativo)
                .HasColumnName("ATIVO")
                .IsRequired();

            builder.HasOne(x => x.Disciplina)
                .WithMany(d => d.Turmas)
                .HasForeignKey(x => x.IdDisciplina);

            builder.HasOne(x => x.Professor)
                .WithMany(d => d.Turmas)
                .HasForeignKey(x => x.IdProfessor);

            builder.HasOne(x => x.Aluno)
                .WithMany(d => d.Turmas)
                .HasForeignKey(x => x.IdAluno);
        }
    }
}
