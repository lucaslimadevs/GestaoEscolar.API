using GEscolar.API.Infra.SqlServer.Data;
using GEscolar.Domain.Entity;
using GEscolar.Domain.Filtros;
using GEscolar.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GEscolarAPI.Infra.SqlServer.Repositories
{
    public class TurmaRepository : BaseRepository<Turma>, ITurmaRepository
    {
        public TurmaRepository(EscolarDbContext context) : base(context)
        {

        }

        public async Task<Turma> FindById(Guid id)
        {
            var turma = await DbSet
                .FirstOrDefaultAsync(e => e.Id == id && e.Ativo);

            return turma ?? new Turma();
        }

        public async Task<FiltroGenerico<Turma>> FindAll(FiltroGenerico<Turma> filtro)
        {
            var query = DbSet
                .Where(e => e.Ativo)
                .AsQueryable();

            filtro.Total = query.Count();

            filtro.Valores = await query
                .Skip((filtro.Pagina - 1) * filtro.QuantidadePorPagina)
                .Take(filtro.QuantidadePorPagina)
                .ToListAsync();

            return filtro;
        }
    }
}
