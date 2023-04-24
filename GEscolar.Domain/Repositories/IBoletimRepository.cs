using GEscolar.Domain.Entity;
using GEscolar.Domain.Filtros;

namespace GEscolar.Domain.Repositories
{
    public interface IBoletimRepository : IBaseRepository<Boletim>
    {
        Task<FiltroGenerico<Boletim>> FindAll(FiltroGenerico<Boletim> filtro);
        Task<Boletim> FindById(Guid id);
    }
}
