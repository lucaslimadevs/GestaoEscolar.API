using GEscolar.Domain.Repositories;
using GEscolar.Domain.Entity;
using GEscolar.Commands.Professores.Command;
using MediatR;

namespace GEscolar.Commands.Professores.Handler
{
    public class InsertProfessorCommandHandler : IRequestHandler<InsertProfessorCommand, bool>
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public InsertProfessorCommandHandler(IProfessorRepository professorRepository, IUnitOfWork unitOfWork)
        {
            _professorRepository = professorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(InsertProfessorCommand request, CancellationToken cancellationToken)
        {
            var entity = new Professor
            {             
                Nome = request.Nome,
                Email = request.Email,
                DataNascimento = request.DataNascimento
            };

            await _professorRepository.AddAsync(entity);

            return await _unitOfWork.CommitAsync();
        }
    }
}
