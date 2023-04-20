using GEscolar.Domain.Repositories;
using GEscolar.Commands.Professores.Command;
using MediatR;
using GEscolar.Queries.Professores.Query;

namespace GEscolar.Commands.Professores.Handler
{
    public class DeleteProfessorCommandHandler : IRequestHandler<DeleteProfessorCommand, bool>
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public DeleteProfessorCommandHandler(IProfessorRepository professorRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _professorRepository = professorRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<bool> Handle(DeleteProfessorCommand request, CancellationToken cancellationToken)
        {
            var professor = await _mediator.Send(new FindProfessorByIdQuery { Id = request.Id });

            if (professor == null) return false;

            professor.Delete();

            _professorRepository.Update(professor);
            return await _unitOfWork.CommitAsync();
        }
    }
}
