using GEscolar.API.Infra.SqlServer.Data;
using GEscolar.Domain.Entity;
using GEscolar.Domain.Filtros;
using GEscolar.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GEscolarAPI.Infra.SqlServer.Repositories
{
    public class DisciplinaRepository : BaseRepository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(EscolarDbContext context) : base(context)
        {
        }

        public async Task<Disciplina> FindById(Guid id)
        {
            var disciplina = await DbSet
                .FirstOrDefaultAsync(e => e.Id == id && e.Ativo);

            return disciplina ?? new Disciplina();
        }

        public async Task<FiltroGenerico<Disciplina>> FindAll(FiltroGenerico<Disciplina> filtro)
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
