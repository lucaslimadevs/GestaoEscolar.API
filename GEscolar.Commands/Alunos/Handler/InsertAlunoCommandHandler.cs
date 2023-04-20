using GEscolar.Commands.Alunos.Command;
using GEscolar.Domain.Entity;
using GEscolar.Domain.Repositories;
using MediatR;

namespace GEscolar.Commands.Alunos.Handler
{
    public class InsertAlunoCommandHandler : IRequestHandler<InsertAlunoCommand, bool>
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertAlunoCommandHandler(IAlunoRepository alunoRepository, IUnitOfWork unitOfWork)
        {
            _alunoRepository = alunoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(InsertAlunoCommand request, CancellationToken cancellationToken)
        {
            var entity = new Aluno
            {
                Nome = request.Nome,
                Email = request.Email,
                DataNascimento = request.DataNascimento
            };

            await _alunoRepository.AddAsync(entity);

            return await _unitOfWork.CommitAsync();

        }
    }
}
