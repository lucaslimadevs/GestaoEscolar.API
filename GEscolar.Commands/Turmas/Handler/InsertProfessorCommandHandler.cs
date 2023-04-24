using GEscolar.Domain.Repositories;
using GEscolar.Domain.Entity;
using MediatR;
using GEscolar.Commands.Turmas.Command;

namespace GEscolar.Commands.Turmas.Handler
{
    public class InsertTurmaCommandHandler : IRequestHandler<InsertTurmaCommand, bool>
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IUnitOfWork _unitOfWork;
        public InsertTurmaCommandHandler(ITurmaRepository turmaRepository, IUnitOfWork unitOfWork)
        {
            _turmaRepository = turmaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(InsertTurmaCommand request, CancellationToken cancellationToken)
        {
            var entity = new Turma
            {             
                IdUsuario = request.IdUsuario,
                IdDisciplina = request.IdDisciplina                
            };

            await _turmaRepository.AddAsync(entity);

            return await _unitOfWork.CommitAsync();
        }
    }
}
