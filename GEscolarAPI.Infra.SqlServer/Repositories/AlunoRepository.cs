using GEscolar.API.Infra.SqlServer.Data;
using GEscolar.Domain.Entity;
using GEscolar.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GEscolarAPI.Infra.SqlServer.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(EscolarDbContext context) : base(context)
        {
        }

        public async Task<Aluno> FindById(Guid id)
        {
            var aluno = await DbSet
                .FirstOrDefaultAsync(e => e.Id == id && e.Ativo);

            return aluno ?? new Aluno();
        }

        public async Task<IEnumerable<Aluno>> FindAllAlunos()
        {
            var query = DbSet
                .Where(e => e.Ativo)
                .AsQueryable();

            return await query.ToListAsync();
        }

    }
}
