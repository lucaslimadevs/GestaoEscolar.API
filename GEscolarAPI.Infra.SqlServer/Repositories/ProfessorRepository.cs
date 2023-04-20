using GEscolar.API.Infra.SqlServer.Data;
using GEscolar.Domain.Entity;
using GEscolar.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GEscolarAPI.Infra.SqlServer.Repositories
{
    public class ProfessorRepository : BaseRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(EscolarDbContext context) : base(context)
        {
        }

        public async Task<Professor> FindById(Guid id)
        {
            var professor = await DbSet
                .FirstOrDefaultAsync(e => e.Id == id && e.Ativo);

            return professor ?? new Professor();
        }

        public async Task<IEnumerable<Professor>> FindAllProfessores()
        {
            var query = DbSet
                .Where(e => e.Ativo)
                .AsQueryable();

            return await query.ToListAsync();
        }
    }
}
