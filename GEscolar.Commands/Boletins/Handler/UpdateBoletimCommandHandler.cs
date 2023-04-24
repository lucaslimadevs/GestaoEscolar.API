using GEscolar.Commands.Boletins.Command;
using GEscolar.Domain.Repositories;
using MediatR;

namespace GEscolar.Commands.Boletins.Handler
{
    public class UpdateBoletimCommandHandler : IRequestHandler<UpdateBoletimCommand, bool>
    {
        private readonly IBoletimRepository _boletimRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public UpdateBoletimCommandHandler(IBoletimRepository boletimRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _boletimRepository = boletimRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<bool> Handle(UpdateBoletimCommand request, CancellationToken cancellationToken)
        {
            var boletim = await _boletimRepository.FindById(request.Id);

            if (boletim is null) return false;

            boletim.IdUsuario = request.IdUsuario;
            boletim.DataEntrega = request.DataEntrega;

            _boletimRepository.Update(boletim);

            return await _unitOfWork.CommitAsync();
        }
    }
}
