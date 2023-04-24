using GEscolar.Domain.Entity;
using GEscolar.Domain.Filtros;
using GEscolar.Domain.Repositories;
using GEscolar.Domain.ViewModels;
using GEscolar.Queries.Turmas.Query;
using MediatR;

namespace GEscolar.Queries.Turmas.Handler
{
    public class FindTurmaQueryHandler : IRequestHandler<FindTurmaQuery, FiltroGenerico<TurmaViewModel>>
    {
        private readonly ITurmaRepository _turmaRepository;
        public FindTurmaQueryHandler(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public async Task<FiltroGenerico<TurmaViewModel>> Handle(FindTurmaQuery request, CancellationToken cancellationToken)
        {
            var filtro = new FiltroGenerico<Turma>
            {
                Pagina = request.Pagina,
                QuantidadePorPagina = request.QuantidadePorPagina
            };
            
            var turmas = await _turmaRepository.FindAll(filtro);  

            var result = new FiltroGenerico<TurmaViewModel>
            {
                Pagina = request.Pagina,
                QuantidadePorPagina = request.QuantidadePorPagina
            };

            result.Valores = turmas.Valores.Select(e => new TurmaViewModel
            {
                Id = e.Id,
                IdDisciplina = e.IdDisciplina,
                IdUsuario = e.IdUsuario,
                Tipo = e.Usuario.Tipo.ToString(),
                NomeDisciplina = e.Disciplina.Nome,
                NomeUsuario = e.Usuario.Nome
            }).ToList();

            result.Total = turmas.Total;

            return result;
        }
    }
}
