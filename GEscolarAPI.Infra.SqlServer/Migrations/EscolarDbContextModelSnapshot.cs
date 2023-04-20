﻿// <auto-generated />
using System;
using GEscolar.API.Infra.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GEscolarAPI.Infra.SqlServer.Migrations
{
    [DbContext(typeof(EscolarDbContext))]
    partial class EscolarDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GEscolar.Domain.Entity.Aluno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDALUNO");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ATIVO");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATANASCIMETO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NOME");

                    b.HasKey("Id");

                    b.ToTable("TBLALUNO", (string)null);
                });

            modelBuilder.Entity("GEscolar.Domain.Entity.Boletim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDBOLETIM");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ATIVO");

                    b.Property<DateTime>("DataEntrega")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATAENTREGA");

                    b.Property<Guid>("IdAluno")
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDALUNO");

                    b.HasKey("Id");

                    b.HasIndex("IdAluno");

                    b.ToTable("TBLBOLETIM", (string)null);
                });

            modelBuilder.Entity("GEscolar.Domain.Entity.Disciplina", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDDISCIPLINA");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ATIVO");

                    b.Property<string>("CargaHoraria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CARGAHORARIA");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NOME");

                    b.HasKey("Id");

                    b.ToTable("TBLDISCIPLINA", (string)null);
                });

            modelBuilder.Entity("GEscolar.Domain.Entity.NotasBoletim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDNOTASBOLETIM");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ATIVO");

                    b.Property<Guid>("IdBoletim")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDBOLETIM");

                    b.Property<Guid>("IdTurma")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDTURMA");

                    b.Property<decimal>("Nota")
                        .HasColumnType("decimal(2,2)")
                        .HasColumnName("NOTA");

                    b.HasKey("Id");

                    b.HasIndex("IdBoletim");

                    b.HasIndex("IdTurma");

                    b.ToTable("TBLNOTASBOLETIM", (string)null);
                });

            modelBuilder.Entity("GEscolar.Domain.Entity.Professor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDPROFESSOR");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ATIVO");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATANASCIMETO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NOME");

                    b.HasKey("Id");

                    b.ToTable("TBLPROFESSOR", (string)null);
                });

            modelBuilder.Entity("GEscolar.Domain.Entity.Turma", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDTURMA");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ATIVO");

                    b.Property<Guid>("IdAluno")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDALUNO");

                    b.Property<Guid>("IdDisciplina")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDDISCIPLINA");

                    b.Property<Guid>("IdProfessor")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDPROFESSOR");

                    b.HasKey("Id");

                    b.HasIndex("IdAluno");

                    b.HasIndex("IdDisciplina");

                    b.HasIndex("IdProfessor");

                    b.ToTable("TBLTURMA", (string)null);
                });

            modelBuilder.Entity("GEscolar.Domain.Entity.Boletim", b =>
                {
                    b.HasOne("GEscolar.Domain.Entity.Aluno", "Aluno")
                        .WithMany("Boletins")
                        .HasForeignKey("IdAluno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("GEscolar.Domain.Entity.NotasBoletim", b =>
                {
                    b.HasOne("GEscolar.Domain.Entity.Boletim", "Boletim")
                        .WithMany("NotasBoletins")
                        .HasForeignKey("IdBoletim")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GEscolar.Domain.Entity.Turma", "Turma")
                        .WithMany("NotasBoletins")
                        .HasForeignKey("IdTurma")
                        .IsRequired();

                    b.Navigation("Boletim");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("GEscolar.Domain.Entity.Turma", b =>
                {
                    b.HasOne("GEscolar.Domain.Entity.Aluno", "Aluno")
                        .WithMany("Turmas")
                        .HasForeignKey("IdAluno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GEscolar.Domain.Entity.Disciplina", "Disciplina")
                        .WithMany("Turmas")
                        .HasForeignKey("IdDisciplina")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GEscolar.Domain.Entity.Professor", "Professor")
                        .WithMany("Turmas")
                        .HasForeignKey("IdProfessor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Disciplina");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("GEscolar.Domain.Entity.Aluno", b =>
                {
                    b.Navigation("Boletins");

                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("GEscolar.Domain.Entity.Boletim", b =>
                {
                    b.Navigation("NotasBoletins");
                });

            modelBuilder.Entity("GEscolar.Domain.Entity.Disciplina", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("GEscolar.Domain.Entity.Professor", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("GEscolar.Domain.Entity.Turma", b =>
                {
                    b.Navigation("NotasBoletins");
                });
#pragma warning restore 612, 618
        }
    }
}
