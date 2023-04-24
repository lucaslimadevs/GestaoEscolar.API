using GEscolar.Commands.NotasBoletins.Command;
using GEscolar.Domain.Repositories;
using MediatR;

namespace GEscolar.Commands.NotasBoletins.Handle
{
    public class UpdateNotasBoletimCommandHandler : IRequestHandler<UpdateNotasBoletimCommand, bool>
    {
        private readonly INotasBoletimRepository _notasBoletimRepository;
        private readonly IUnitOfWork _unitOfWork;        
        public UpdateNotasBoletimCommandHandler(INotasBoletimRepository notasBoletimRepository, IUnitOfWork unitOfWork)
        {
            _notasBoletimRepository = notasBoletimRepository;
            _unitOfWork = unitOfWork;            
        }

        public async Task<bool> Handle(UpdateNotasBoletimCommand request, CancellationToken cancellationToken)
        {
            var notasBoletim = await _notasBoletimRepository.FindById(request.Id);

            if (notasBoletim is null) return false;

            notasBoletim.IdBoletim = request.IdBoletim;
            notasBoletim.IdTurma = request.IdTurma;
            notasBoletim.Nota = request.Nota;

            _notasBoletimRepository.Update(notasBoletim);

            return await _unitOfWork.CommitAsync();
        }
    }
}
