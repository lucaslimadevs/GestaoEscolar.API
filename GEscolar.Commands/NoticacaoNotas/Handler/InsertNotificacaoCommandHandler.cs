using GEscolar.Commands.NoticacaoNotas.Command;
using GEscolar.Domain.Entity;
using GEscolar.Domain.Repositories;
using MediatR;

namespace GEscolar.Commands.NoticacaoNotas.Handler
{
    public class InsertNotificacaoCommandHandler : IRequestHandler<InsertNotificacaoCommand, bool>
    {
        private readonly INotificacaoNotaRepository _notificacaoNotaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertNotificacaoCommandHandler(
            INotificacaoNotaRepository notificacaoNotaRepository, 
            IUnitOfWork unitOfWork)
        {
            _notificacaoNotaRepository = notificacaoNotaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(InsertNotificacaoCommand request, CancellationToken cancellationToken)
        {
            var notificacao = new NotificacaoNota
            {
                IdUsuario = request.IdUsuario,
                IdDisciplina = request.IdDisciplina,
                Nota = request.Nota
            };

            await _notificacaoNotaRepository.AddAsync(notificacao);

            return await _unitOfWork.CommitAsync();
        }
    }
}
