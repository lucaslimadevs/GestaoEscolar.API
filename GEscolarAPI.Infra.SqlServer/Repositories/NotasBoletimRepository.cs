using GEscolar.API.Infra.SqlServer.Data;
using GEscolar.Domain.Entity;
using GEscolar.Domain.Filtros;
using GEscolar.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GEscolarAPI.Infra.SqlServer.Repositories
{
    public class NotasBoletimRepository : BaseRepository<NotasBoletim>, INotasBoletimRepository
    {
        public NotasBoletimRepository(EscolarDbContext context) : base(context)
        {
        }

        public async Task<NotasBoletim> FindById(Guid id)
        {
            var notasBoletim = await DbSet
                .Include(e => e.Turma)
                    .ThenInclude(p => p.Disciplina)
                .Include(e => e.Boletim)
                    .ThenInclude(p => p.Usuario)
                .FirstOrDefaultAsync(e => e.Id == id && e.Ativo);

            return notasBoletim ?? new NotasBoletim();
        }

        public async Task<FiltroGenerico<NotasBoletim>> FindAll(FiltroGenerico<NotasBoletim> filtro)
        {
            var query = DbSet
                .Include(e => e.Turma)
                    .ThenInclude(p => p.Disciplina)
                .Include(e => e.Boletim)
                    .ThenInclude(p => p.Usuario)
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
