using GEscolar.Commands.Alunos.Command;
using GEscolar.Domain.Repositories;
using GEscolar.Queries.Alunos.Query;
using GEscolar.Queries.Professores.Query;
using GEscolarAPI.Infra.SqlServer.Repositories;
using MediatR;

namespace GEscolar.Commands.Alunos.Handler
{
    public class DeleteAlunoCommandHandler : IRequestHandler<DeleteAlunoCommand, bool>
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public DeleteAlunoCommandHandler(IAlunoRepository alunoRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _alunoRepository = alunoRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<bool> Handle(DeleteAlunoCommand request, CancellationToken cancellationToken)
        {
            var aluno = await _mediator.Send(new FindAlunoByIdQuery { Id = request.Id });

            if (aluno == null) return false;

            aluno.Delete();

            _alunoRepository.Update(aluno);
            return await _unitOfWork.CommitAsync();
        }
    }
}
