using GEscolar.Domain.Entity;
using GEscolar.Domain.Filtros;

namespace GEscolar.Domain.Repositories
{
    public interface INotasBoletimRepository : IBaseRepository<NotasBoletim>
    {
        Task<NotasBoletim> FindById(Guid id);
        Task<FiltroGenerico<NotasBoletim>> FindAll(FiltroGenerico<NotasBoletim> filtro);
    }
}
