using GEscolar.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GEscolar.API.Infra.SqlServer.Mapping
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("TBLALUNO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IDALUNO")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.DataNascimento)
                .HasColumnName("DATANASCIMETO")
                .IsRequired();

            builder.Property(x => x.Ativo)
                .HasColumnName("ATIVO")
                .IsRequired();

            builder.HasMany(x => x.Boletins)
                .WithOne(d => d.Aluno)
                .HasForeignKey(x => x.IdAluno);

            builder.HasMany(x => x.Turmas)
                .WithOne(d => d.Aluno)
                .HasForeignKey(x => x.IdAluno);
        }
    }
}
