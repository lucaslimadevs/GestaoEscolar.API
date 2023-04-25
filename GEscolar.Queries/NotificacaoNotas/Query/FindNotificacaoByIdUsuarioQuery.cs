using GEscolar.Domain.Entity;
using GEscolar.Domain.ViewModels;
using MediatR;

namespace GEscolar.Queries.NotificacaoNotas.Query
{
    public class FindNotificacaoByIdUsuarioQuery : IRequest<IEnumerable<NotificacaoNotaViewModel>>
    {
        public Guid IdUsuario { get; set; }
    }
}
