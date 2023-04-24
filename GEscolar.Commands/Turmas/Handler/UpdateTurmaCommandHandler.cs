using GEscolar.Domain.Repositories;
using MediatR;
using GEscolar.Commands.Turmas.Command;

namespace GEscolar.Commands.Turmas.Handler
{
    public class UpdateTurmaCommandHandler : IRequestHandler<UpdateTurmaCommand, bool>
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public UpdateTurmaCommandHandler(ITurmaRepository turmaRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _turmaRepository = turmaRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<bool> Handle(UpdateTurmaCommand request, CancellationToken cancellationToken)
        {
            var turma = await _turmaRepository.FindById(request.Id);

            if (turma is null) return false;

            turma.IdUsuario = request.IdUsuario;
            turma.IdDisciplina = request.IdDisciplina;            

            _turmaRepository.Update(turma);

            return await _unitOfWork.CommitAsync();
        }
    }
}
