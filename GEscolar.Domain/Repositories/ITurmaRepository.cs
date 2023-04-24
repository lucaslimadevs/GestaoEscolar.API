using GEscolar.Domain.Entity;
using GEscolar.Domain.Filtros;
using GEscolar.Domain.ViewModels;

namespace GEscolar.Domain.Repositories
{
    public interface ITurmaRepository : IBaseRepository<Turma>
    {
        Task<FiltroGenerico<Turma>> FindAll(FiltroGenerico<Turma> filtro);
        Task<Turma> FindById(Guid id);
    }
}
