using GEscolar.Commands.Boletins.Command;
using GEscolar.Domain.Entity;
using GEscolar.Domain.Repositories;
using MediatR;

namespace GEscolar.Commands.Boletins.Handler
{
    public class InsertBoletimCommandHandler : IRequestHandler<InsertBoletimCommand, bool>
    {
        private readonly IBoletimRepository _boletimRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertBoletimCommandHandler(IBoletimRepository boletimRepository, IUnitOfWork unitOfWork)
        {
            _boletimRepository = boletimRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(InsertBoletimCommand request, CancellationToken cancellationToken)
        {
            var entity = new Boletim
            {
                DataEntrega = request.DataEntrega,
                IdUsuario = request.IdUsuario
            };

            await _boletimRepository.AddAsync(entity);

            return await _unitOfWork.CommitAsync();
        }
    }
}
