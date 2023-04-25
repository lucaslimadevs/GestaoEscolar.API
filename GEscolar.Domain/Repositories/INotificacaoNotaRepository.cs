using GEscolar.Domain.Entity;

namespace GEscolar.Domain.Repositories
{
    public interface INotificacaoNotaRepository : IBaseRepository<NotificacaoNota>
    {
        Task<IEnumerable<NotificacaoNota>> FindByIdUsuario(Guid idUsuario);

        Task<NotificacaoNota> FindById(Guid id);
    }
}
