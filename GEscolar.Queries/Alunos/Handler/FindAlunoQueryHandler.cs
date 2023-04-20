using GEscolar.Domain.Entity;
using GEscolar.Domain.Repositories;
using GEscolar.Queries.Alunos.Query;
using MediatR;

namespace GEscolar.Queries.Alunos.Handler
{
    public class FindAlunoQueryHandler : IRequestHandler<FindAlunoQuery, IEnumerable<Aluno>>
    {
        private readonly IAlunoRepository _alunoRepository;
        public FindAlunoQueryHandler(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public Task<IEnumerable<Aluno>> Handle(FindAlunoQuery request, CancellationToken cancellationToken)
        {
            return _alunoRepository.FindAllAlunos();
        }
    }
}
