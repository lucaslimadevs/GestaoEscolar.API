using GEscolar.Domain.Entity;
using GEscolar.Domain.Filtros;

namespace GEscolar.Domain.Repositories
{
    public interface IDisciplinaRepository : IBaseRepository<Disciplina>
    {
        Task<FiltroGenerico<Disciplina>> FindAll(FiltroGenerico<Disciplina> filtro);
        Task<Disciplina> FindById(Guid id);
    }
}
