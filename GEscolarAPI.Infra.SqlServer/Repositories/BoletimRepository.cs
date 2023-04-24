using GEscolar.API.Infra.SqlServer.Data;
using GEscolar.Domain.Entity;
using GEscolar.Domain.Filtros;
using GEscolar.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GEscolarAPI.Infra.SqlServer.Repositories
{
    public class BoletimRepository : BaseRepository<Boletim>, IBoletimRepository
    {
        public BoletimRepository(EscolarDbContext context) : base(context)
        {
        }

        public async Task<Boletim> FindById(Guid id)
        {
            var boletim = await DbSet                
                .Include(e => e.Usuario)
                .FirstOrDefaultAsync(e => e.Id == id && e.Ativo);

            return boletim ?? new Boletim();
        }

        public async Task<FiltroGenerico<Boletim>> FindAll(FiltroGenerico<Boletim> filtro)
        {
            var query = DbSet                
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
