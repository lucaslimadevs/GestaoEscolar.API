using GEscolar.Domain.Entity;
using GEscolar.Domain.Filtros;
using GEscolar.Domain.Repositories;
using GEscolar.Domain.ViewModels;
using GEscolar.Queries.Boletins.Query;
using GEscolarAPI.Infra.SqlServer.Repositories;
using MediatR;

namespace GEscolar.Queries.Boletins.Handler
{
    public class FindBoletimQueryHandler : IRequestHandler<FindBoletimQuery, FiltroGenerico<BoletimViewModel>>
    {
        private readonly IBoletimRepository _boletimRepository;
        public FindBoletimQueryHandler(IBoletimRepository boletimRepository)
        {
            _boletimRepository = boletimRepository;
        }

        public async Task<FiltroGenerico<BoletimViewModel>> Handle(FindBoletimQuery request, CancellationToken cancellationToken)
        {
            var filtro = new FiltroGenerico<Boletim>
            {
                Pagina = request.Pagina,
                QuantidadePorPagina = request.QuantidadePorPagina
            };

            var boletins = await _boletimRepository.FindAll(filtro);

            var result = new FiltroGenerico<BoletimViewModel>
            {
                Pagina = request.Pagina,
                QuantidadePorPagina = request.QuantidadePorPagina
            };

            result.Valores = boletins.Valores.Select(e => new BoletimViewModel
            {
                Id = e.Id,                
                IdUsuario = e.IdUsuario,                
                DataEntrega = e.DataEntrega,
                NomeUsuario = e.Usuario.Nome
            }).ToList();

            result.Total = boletins.Total;

            return result;
        }
    }
}
