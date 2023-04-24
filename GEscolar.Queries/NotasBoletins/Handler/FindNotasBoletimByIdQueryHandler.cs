using GEscolar.Domain.Repositories;
using GEscolar.Domain.ViewModels;
using GEscolar.Queries.NotasBoletins.Query;
using MediatR;

namespace GEscolar.Queries.NotasBoletins.Handler
{
    public class FindNotasBoletimByIdQueryHandler : IRequestHandler<FindNotasBoletimByIdQuery, NotasBoletimViewModel>
    {
        private readonly INotasBoletimRepository _notasBoletimRepository;
        public FindNotasBoletimByIdQueryHandler(INotasBoletimRepository notasBoletimRepository)
        {
            _notasBoletimRepository = notasBoletimRepository;
        }

        public async Task<NotasBoletimViewModel> Handle(FindNotasBoletimByIdQuery request, CancellationToken cancellationToken)
        {
            var notasBoletim = await _notasBoletimRepository.FindById(request.Id);

            var result = new NotasBoletimViewModel()
            {
                Id = notasBoletim.Id,
                IdTurma = notasBoletim.IdTurma,
                IdBoletim = notasBoletim.IdBoletim,
                NomeDisciplina = notasBoletim.Turma.Disciplina.Nome,
                NomeUsuario = notasBoletim.Boletim.Usuario.Nome
            };

            return result;
        }
    }
}
