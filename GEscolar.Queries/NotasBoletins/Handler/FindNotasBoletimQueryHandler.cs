using GEscolar.Domain.Entity;
using GEscolar.Domain.Filtros;
using GEscolar.Domain.Repositories;
using GEscolar.Domain.ViewModels;
using GEscolar.Queries.NotasBoletins.Query;
using MediatR;

namespace GEscolar.Queries.NotasBoletins.Handler
{
    public class FindNotasBoletimQueryHandler : IRequestHandler<FindNotasBoletimQuery, FiltroGenerico<NotasBoletimViewModel>>
    {
        private readonly INotasBoletimRepository _notasBoletimRepository;
        public FindNotasBoletimQueryHandler(INotasBoletimRepository notasBoletimRepository)
        {
            _notasBoletimRepository = notasBoletimRepository;
        }

        public async Task<FiltroGenerico<NotasBoletimViewModel>> Handle(FindNotasBoletimQuery request, CancellationToken cancellationToken)
        {
            var filtro = new FiltroGenerico<NotasBoletim>
            {
                Pagina = request.Pagina,
                QuantidadePorPagina = request.QuantidadePorPagina
            };

            var notasBoletims = await _notasBoletimRepository.FindAll(filtro);

            var result = new FiltroGenerico<NotasBoletimViewModel>
            {
                Pagina = request.Pagina,
                QuantidadePorPagina = request.QuantidadePorPagina
            };

            result.Valores = notasBoletims.Valores.Select(e => new NotasBoletimViewModel
            {
                Id = e.Id,
                IdTurma = e.IdTurma,
                IdBoletim = e.IdBoletim,
                NomeDisciplina = e.Turma.Disciplina.Nome,
                NomeUsuario = e.Boletim.Usuario.Nome,
                Nota = e.Nota
            }).ToList();

            result.Total = notasBoletims.Total;

            return result;
        }
    }
}
