using GEscolar.Domain.Entity;
using GEscolar.Domain.Filtros;

namespace GEscolar.Domain.Repositories
{
    public interface ITurmaRepository : IBaseRepository<Turma>
    {
        Task<FiltroGenerico<Turma>> FindAll(FiltroGenerico<Turma> filtro);
        Task<Turma> FindById(Guid id);
    }
}
