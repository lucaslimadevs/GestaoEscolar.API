using GEscolar.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GEscolar.API.Infra.SqlServer.Mapping
{
    public class NotificacaoNotaMap : IEntityTypeConfiguration<NotificacaoNota>
    {
        public void Configure(EntityTypeBuilder<NotificacaoNota> builder)
        {
            builder.ToTable("TBLNOTIFICACAONOTA");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IDNOTIFICACAONOTA")
                .IsRequired();

            builder.Property(x => x.IdUsuario)
                .HasColumnName("IDUSUARIO")                
                .IsRequired();

            builder.Property(x => x.IdDisciplina)
                .HasColumnName("IDDISCIPLINA")
                .IsRequired();

            builder.Property(x => x.Nota)
                .HasColumnName("NOTA")
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(x => x.Ativo)
                .HasColumnName("ATIVO")
                .IsRequired();

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.IdUsuario);

            builder.HasOne(x => x.Disciplina)
                .WithMany(d => d.NotificacaoNotas)
                .HasForeignKey(x => x.IdDisciplina);
        }
    }
}
