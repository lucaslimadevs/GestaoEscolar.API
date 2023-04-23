using GEscolar.Commands.Disciplinas.Command;
using GEscolar.Domain.Repositories;
using GEscolar.Queries.Disciplinas.Query;
using MediatR;

namespace GEscolar.Commands.Disciplinas.Handler
{
    public class DeleteDisciplinaCommandHandler : IRequestHandler<DeleteDisciplinaCommand, bool>
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public DeleteDisciplinaCommandHandler(IDisciplinaRepository disciplinaRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _disciplinaRepository = disciplinaRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<bool> Handle(DeleteDisciplinaCommand request, CancellationToken cancellationToken)
        {
            var disciplina = await _mediator.Send(new FindDisciplinaByIdQuery { Id = request.Id });

            if (disciplina == null) return false;

            disciplina.Delete();

            _disciplinaRepository.Update(disciplina);
            return await _unitOfWork.CommitAsync();
        }
    }
}
