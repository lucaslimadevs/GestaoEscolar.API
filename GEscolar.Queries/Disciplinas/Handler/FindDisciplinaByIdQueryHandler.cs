using GEscolar.Domain.Entity;
using GEscolar.Domain.Repositories;
using GEscolar.Queries.Disciplinas.Query;
using MediatR;

namespace GEscolar.Queries.Disciplinas.Handler
{
    public class FindDisciplinaByIdQueryHandler : IRequestHandler<FindDisciplinaByIdQuery, Disciplina>
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        public FindDisciplinaByIdQueryHandler(IDisciplinaRepository disciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;
        }

        public async Task<Disciplina> Handle(FindDisciplinaByIdQuery request, CancellationToken cancellationToken)
        {
            return await _disciplinaRepository.FindById(request.Id);
        }

    }
}
