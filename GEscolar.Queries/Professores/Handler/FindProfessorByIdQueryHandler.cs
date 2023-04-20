using GEscolar.Domain.Entity;
using GEscolar.Domain.Repositories;
using GEscolar.Queries.Professores.Query;
using MediatR;

namespace GEscolar.Queries.Professores.Handler
{
    public class FindProfessorByIdQueryHandler : IRequestHandler<FindProfessorByIdQuery, Professor>
    {
        private readonly IProfessorRepository _professorRepository;
        public FindProfessorByIdQueryHandler(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task<Professor> Handle(FindProfessorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _professorRepository.FindById(request.Id);
        }
    }
}
