using GEscolar.Domain.Repositories;
using MediatR;
using GEscolar.Commands.Turmas.Command;
using GEscolar.Queries.Turmas.Query;

namespace GEscolar.Commands.Turmas.Handler
{
    public class DeleteTurmaCommandHandler : IRequestHandler<DeleteTurmaCommand, bool>
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public DeleteTurmaCommandHandler(ITurmaRepository turmaRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _turmaRepository = turmaRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<bool> Handle(DeleteTurmaCommand request, CancellationToken cancellationToken)
        {
            var turma = await _turmaRepository.FindById(request.Id);

            if (turma == null) return false;

            turma.Delete();

            _turmaRepository.Update(turma);
            return await _unitOfWork.CommitAsync();
        }
    }
}
