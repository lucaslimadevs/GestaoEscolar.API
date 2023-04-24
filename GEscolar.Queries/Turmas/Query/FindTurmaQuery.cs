using GEscolar.Domain.Entity;
using GEscolar.Domain.Filtros;
using GEscolar.Domain.ViewModels;
using MediatR;

namespace GEscolar.Queries.Turmas.Query
{
    public class FindTurmaQuery : IRequest<FiltroGenerico<TurmaViewModel>>
    {
        public int? QuantidadePorPagina { get; set; }
        public int Pagina { get; set; }

    }
}
