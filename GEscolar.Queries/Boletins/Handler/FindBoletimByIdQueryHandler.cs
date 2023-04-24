using GEscolar.Domain.Repositories;
using GEscolar.Domain.ViewModels;
using GEscolar.Queries.Boletins.Query;
using MediatR;

namespace GEscolar.Queries.Boletins.Handler
{
    internal class FindBoletimByIdQueryHandler : IRequestHandler<FindBoletimByIdQuery, BoletimViewModel>
    {    
        private readonly IBoletimRepository _boletimRepository;
        public FindBoletimByIdQueryHandler(IBoletimRepository boletimRepository)
        {
            _boletimRepository = boletimRepository;
        }

        public async Task<BoletimViewModel> Handle(FindBoletimByIdQuery request, CancellationToken cancellationToken)
        {
            var boletim = await _boletimRepository.FindById(request.Id);

            var result = new BoletimViewModel()
            {
                Id = boletim.Id,                
                IdUsuario = boletim.IdUsuario,                
                NomeUsuario = boletim.Usuario.Nome,
                DataEntrega = boletim.DataEntrega,
            };

            return result;
        }

    }
}
