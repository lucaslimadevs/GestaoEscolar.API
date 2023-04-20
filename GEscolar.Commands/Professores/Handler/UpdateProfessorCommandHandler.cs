using GEscolar.Domain.Repositories;
using GEscolar.Domain.Entity;
using GEscolar.Commands.Professores.Command;
using MediatR;
using GEscolar.Queries.Professores.Query;

namespace GEscolar.Commands.Professores.Handler
{
    public class UpdateProfessorCommandHandler : IRequestHandler<UpdateProfessorCommand, bool>
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public UpdateProfessorCommandHandler(IProfessorRepository professorRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _professorRepository = professorRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<bool> Handle(UpdateProfessorCommand request, CancellationToken cancellationToken)
        {
            var professor = await _mediator.Send(new FindProfessorByIdQuery { Id = request.Id });

            if (professor is null) return false;

            professor.Nome = request.Nome;
            professor.Email = request.Email;
            professor.DataNascimento = request.DataNascimento;

            _professorRepository.Update(professor);

            return await _unitOfWork.CommitAsync();
        }
    }
}
