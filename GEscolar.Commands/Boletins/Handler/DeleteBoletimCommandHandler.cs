using GEscolar.Commands.Boletins.Command;
using GEscolar.Domain.Repositories;
using MediatR;

namespace GEscolar.Commands.Boletins.Handler
{
    public class DeleteBoletimCommandHandler : IRequestHandler<DeleteBoletimCommand, bool>
    {
        private readonly IBoletimRepository _boletimRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public DeleteBoletimCommandHandler(IBoletimRepository boletimRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _boletimRepository = boletimRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<bool> Handle(DeleteBoletimCommand request, CancellationToken cancellationToken)
        {
            var boletim = await _boletimRepository.FindById(request.Id);

            if (boletim == null) return false;

            boletim.Delete();

            _boletimRepository.Update(boletim);
            return await _unitOfWork.CommitAsync();
        }
    }
}
