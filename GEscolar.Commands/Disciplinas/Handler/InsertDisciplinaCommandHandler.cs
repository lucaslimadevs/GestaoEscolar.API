using GEscolar.Commands.Disciplinas.Command;
using GEscolar.Domain.Entity;
using GEscolar.Domain.Repositories;
using MediatR;

namespace GEscolar.Commands.Disciplinas.Handler
{
    public class InsertDisciplinaCommandHandler : IRequestHandler<InsertDisciplinaCommand, bool>
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertDisciplinaCommandHandler(IDisciplinaRepository disciplinaRepository, IUnitOfWork unitOfWork)
        {
            _disciplinaRepository = disciplinaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(InsertDisciplinaCommand request, CancellationToken cancellationToken)
        {
            var entity = new Disciplina
            {
                Nome = request.Nome,
                CargaHoraria = request.CargaHoraria
            };

            await _disciplinaRepository.AddAsync(entity);

            return await _unitOfWork.CommitAsync();
        }
    }
}
