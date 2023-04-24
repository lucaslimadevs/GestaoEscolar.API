using GEscolar.Domain.Entity;

namespace GEscolar.Domain.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> FindAll();
    }
}
