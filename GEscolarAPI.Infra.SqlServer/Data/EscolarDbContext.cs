using GEscolar.Domain.Entity;
using GEscolar.API.Infra.SqlServer.Mapping;
using Microsoft.EntityFrameworkCore;
using Utils;

namespace GEscolar.API.Infra.SqlServer.Data
{
    public class EscolarDbContext : DbContext
    {
        public EscolarDbContext(DbContextOptions<EscolarDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Boletim> Boletims { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<NotasBoletim> NotasBoletim { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfiguration(new BoletimMap());
            modelBuilder.ApplyConfiguration(new DisciplinaMap());
            modelBuilder.ApplyConfiguration(new NotasBoletimMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            base.OnModelCreating(modelBuilder);            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                        
            optionsBuilder.UseSqlServer(Variables.DefaultConnection);
        }
    }
}
