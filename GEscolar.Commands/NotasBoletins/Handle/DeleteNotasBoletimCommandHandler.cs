using GEscolar.Commands.NotasBoletins.Command;
using GEscolar.Domain.Repositories;
using MediatR;

namespace GEscolar.Commands.NotasBoletins.Handle
{
    public class DeleteNotasBoletimCommandHandler : IRequestHandler<DeleteNotasBoletimCommand, bool>
    {
        private readonly INotasBoletimRepository _notasBoletimRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteNotasBoletimCommandHandler(INotasBoletimRepository notasBoletimRepository, IUnitOfWork unitOfWork)
        {
            _notasBoletimRepository = notasBoletimRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteNotasBoletimCommand request, CancellationToken cancellationToken)
        {
            var notasBoletim = await _notasBoletimRepository.FindById(request.Id);

            if (notasBoletim == null) return false;

            notasBoletim.Delete();

            _notasBoletimRepository.Update(notasBoletim);
            return await _unitOfWork.CommitAsync();
        }
    }
}
