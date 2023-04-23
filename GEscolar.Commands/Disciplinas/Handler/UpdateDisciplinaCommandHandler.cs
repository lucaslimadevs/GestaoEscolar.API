using GEscolar.Commands.Disciplinas.Command;
using GEscolar.Domain.Repositories;
using GEscolar.Queries.Disciplinas.Query;
using MediatR;

namespace GEscolar.Commands.Disciplinas.Handler
{
    public class UpdateDisciplinaCommandHandler : IRequestHandler<UpdateDisciplinaCommand, bool>
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public UpdateDisciplinaCommandHandler(IDisciplinaRepository disciplinaRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _disciplinaRepository = disciplinaRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<bool> Handle(UpdateDisciplinaCommand request, CancellationToken cancellationToken)
        {
            var disciplina = await _mediator.Send(new FindDisciplinaByIdQuery { Id = request.Id });

            if (disciplina is null) return false;

            disciplina.Nome = request.Nome;
            disciplina.CargaHoraria = request.CargaHoraria;

            _disciplinaRepository.Update(disciplina);

            return await _unitOfWork.CommitAsync();
        }
    }
}
