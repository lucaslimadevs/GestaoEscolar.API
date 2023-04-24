using GEscolar.Domain.Entity;
using GEscolar.Domain.Filtros;
using GEscolar.Domain.ViewModels;
using MediatR;

namespace GEscolar.Queries.Boletins.Query
{
    public class FindBoletimQuery : IRequest<FiltroGenerico<BoletimViewModel>>
    {
        public int? QuantidadePorPagina { get; set; }
        public int Pagina { get; set; }
    }
}
