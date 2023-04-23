using GEscolar.Domain.Entity;
using GEscolar.Domain.Filtros;
using MediatR;

namespace GEscolar.Queries.Disciplinas.Query
{
    public class FindDisciplinaQuery : IRequest<FiltroGenerico<Disciplina>>
    {
        public int QuantidadePorPagina { get; set; }
        public int Pagina { get; set; }
    }
}
