using GEscolar.Domain.Entity;
using GEscolar.Domain.Repositories;
using GEscolar.Domain.ViewModels;
using GEscolar.Queries.Turmas.Query;
using MediatR;

namespace GEscolar.Queries.Turmas.Handler
{
    public class FindTurmaByIdQueryHandler : IRequestHandler<FindTurmaByIdQuery, TurmaViewModel>
    {
        private readonly ITurmaRepository _turmaRepository;
        public FindTurmaByIdQueryHandler(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public async Task<TurmaViewModel> Handle(FindTurmaByIdQuery request, CancellationToken cancellationToken)
        {
            var turma = await _turmaRepository.FindById(request.Id);

            var result = new TurmaViewModel()
            {
                Id = turma.Id,
                IdDisciplina = turma.IdDisciplina,
                IdUsuario = turma.IdUsuario,
                NomeDisciplina = turma.Disciplina.Nome,
                NomeUsuario = turma.Usuario.Nome
            };

            return result;
        }
    }
}
