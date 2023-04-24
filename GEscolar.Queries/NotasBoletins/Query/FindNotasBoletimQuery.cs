using GEscolar.Domain.Filtros;
using GEscolar.Domain.ViewModels;
using MediatR;

namespace GEscolar.Queries.NotasBoletins.Query
{
    public class FindNotasBoletimQuery : IRequest<FiltroGenerico<NotasBoletimViewModel>>
    {
        public int QuantidadePorPagina { get; set; }
        public int Pagina { get; set; }
    }
}
