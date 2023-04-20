using GEscolar.Commands.Alunos.Command;
using GEscolar.Domain.Repositories;
using GEscolar.Queries.Alunos.Query;
using MediatR;

namespace GEscolar.Commands.Alunos.Handler
{
    public class UpdateAlunoCommandHandler : IRequestHandler<UpdateAlunoCommand, bool>
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public UpdateAlunoCommandHandler(IAlunoRepository alunoRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _alunoRepository = alunoRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<bool> Handle(UpdateAlunoCommand request, CancellationToken cancellationToken)
        {
            var aluno = await _mediator.Send(new FindAlunoByIdQuery { Id = request.Id });

            if (aluno is null) return false;

            aluno.Nome = request.Nome;
            aluno.Email = request.Email;
            aluno.DataNascimento = request.DataNascimento;

            _alunoRepository.Update(aluno);

            return await _unitOfWork.CommitAsync();
        }
    }
}
