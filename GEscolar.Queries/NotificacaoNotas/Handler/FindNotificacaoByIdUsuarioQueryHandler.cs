using GEscolar.Domain.Repositories;
using GEscolar.Domain.ViewModels;
using GEscolar.Queries.NotificacaoNotas.Query;
using MediatR;

namespace GEscolar.Queries.NotificacaoNotas.Handler
{
    public class FindNotificacaoByIdUsuarioQueryHandler : IRequestHandler<FindNotificacaoByIdUsuarioQuery, IEnumerable<NotificacaoNotaViewModel>>
    {
        private readonly INotificacaoNotaRepository _notificacaoNotaRepository;

        public FindNotificacaoByIdUsuarioQueryHandler(INotificacaoNotaRepository notificacaoNotaRepository)
        {
            _notificacaoNotaRepository = notificacaoNotaRepository;
        }

        public async Task<IEnumerable<NotificacaoNotaViewModel>> Handle(FindNotificacaoByIdUsuarioQuery request, CancellationToken cancellationToken)
        {
            var notificacoes = await _notificacaoNotaRepository.FindByIdUsuario(request.IdUsuario);

            var result = notificacoes.Select(e => new NotificacaoNotaViewModel
            {
                Id = e.Id,
                IdDisciplina = e.IdDisciplina,
                IdUsuario = e.IdUsuario,
                NomeDisciplina = e.Disciplina.Nome,
                NomeUsuario = e.Usuario.Nome,
                Nota = e.Nota
            });

            return result;
        }
    }
}
