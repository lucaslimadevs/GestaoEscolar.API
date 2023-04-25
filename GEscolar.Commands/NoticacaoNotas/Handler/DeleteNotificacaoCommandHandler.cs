using GEscolar.Commands.NoticacaoNotas.Command;
using GEscolar.Domain.Repositories;
using MediatR;

namespace GEscolar.Commands.NoticacaoNotas.Handler
{
    public class DeleteNotificacaoCommandHandler : IRequestHandler<DeleteNotificacaoCommand, bool>
    {
        private readonly INotificacaoNotaRepository _notificacaoNotaRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteNotificacaoCommandHandler(INotificacaoNotaRepository notificacaoNotaRepository, IUnitOfWork unitOfWork)
        {
            _notificacaoNotaRepository = notificacaoNotaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteNotificacaoCommand request, CancellationToken cancellationToken)
        {
            var turma = await _notificacaoNotaRepository.FindById(request.Id);

            if (turma == null) return false;

            turma.Delete();

            _notificacaoNotaRepository.Update(turma);
            return await _unitOfWork.CommitAsync();

        }
    }
}
