using GEscolar.API.Infra.SqlServer.Data;
using GEscolar.Domain.Entity;
using GEscolar.Domain.Filtros;
using GEscolar.Domain.Repositories;
using GEscolar.Domain.ViewModels;
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
                .Include(e => e.Disciplina)
                .Include(e => e.Usuario)
                .FirstOrDefaultAsync(e => e.Id == id && e.Ativo);

            return turma ?? new Turma();
        }

        public async Task<FiltroGenerico<Turma>> FindAll(FiltroGenerico<Turma> filtro)
        {
            var query = DbSet
                .Include(e => e.Disciplina)
                .Include(e => e.Usuario)
                .Where(e => e.Ativo)
                .AsQueryable();

            filtro.Total = query.Count();

            if (filtro.QuantidadePorPagina is null)
            {
                filtro.Valores = await query.ToListAsync();
            }
            else
            {
                filtro.Valores = await query
                    .Skip((filtro.Pagina - 1) * filtro.QuantidadePorPagina ?? 1)
                    .Take(filtro.QuantidadePorPagina ?? 1)
                    .ToListAsync();
            }

            return filtro;
        }
    }
}
