using GEscolar.Domain.Entity;
using GEscolar.Domain.Repositories;
using GEscolar.Queries.Professores.Query;
using GEscolarAPI.Infra.SqlServer.Repositories;
using MediatR;

namespace GEscolar.Queries.Professores.Handler
{
    public class FindProfessorQueryHandler : IRequestHandler<FindProfessorQuery, IEnumerable<Professor>>
    {
        private readonly IProfessorRepository _professorRepository;
        public FindProfessorQueryHandler(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public Task<IEnumerable<Professor>> Handle(FindProfessorQuery request, CancellationToken cancellationToken)
        {
            return _professorRepository.FindAllProfessores();
        }
    }
}
