using GEscolar.Domain.Entity;
using GEscolar.Domain.Repositories;
using GEscolar.Queries.Alunos.Query;
using MediatR;

namespace GEscolar.Queries.Alunos.Handler
{
    public class FindAlunoByIdQueryHandler : IRequestHandler<FindAlunoByIdQuery, Aluno>
    {
        private readonly IAlunoRepository _alunoRepository;
        public FindAlunoByIdQueryHandler(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<Aluno> Handle(FindAlunoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _alunoRepository.FindById(request.Id);
        }

    }
}
