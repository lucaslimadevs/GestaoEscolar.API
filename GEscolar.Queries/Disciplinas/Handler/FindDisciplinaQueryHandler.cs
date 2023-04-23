using GEscolar.Domain.Entity;
using GEscolar.Domain.Filtros;
using GEscolar.Domain.Repositories;
using GEscolar.Queries.Disciplinas.Query;
using MediatR;

namespace GEscolar.Queries.Disciplinas.Handler
{
    public class FindDisciplinaQueryHandler : IRequestHandler<FindDisciplinaQuery, FiltroGenerico<Disciplina>>
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        public FindDisciplinaQueryHandler(IDisciplinaRepository disciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;
        }

        public Task<FiltroGenerico<Disciplina>> Handle(FindDisciplinaQuery request, CancellationToken cancellationToken)
        {
            var filtro = new FiltroGenerico<Disciplina>
            {
                Pagina = request.Pagina,
                QuantidadePorPagina = request.QuantidadePorPagina
            };

            return _disciplinaRepository.FindAll(filtro);
        }
    }
}
