using GEscolar.Commands.NotasBoletins.Command;
using GEscolar.Domain.Entity;
using GEscolar.Domain.Repositories;
using MediatR;

namespace GEscolar.Commands.NotasBoletins.Handle
{
    public class InsertNotasBoletimCommandHandler : IRequestHandler<InsertNotasBoletimCommand, bool>
    {
        private readonly INotasBoletimRepository _notasBoletimRepository;
        private readonly IUnitOfWork _unitOfWork;
        public InsertNotasBoletimCommandHandler(INotasBoletimRepository notasBoletimRepository, IUnitOfWork unitOfWork)
        {
            _notasBoletimRepository = notasBoletimRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(InsertNotasBoletimCommand request, CancellationToken cancellationToken)
        {
            var entity = new NotasBoletim
            {
                IdBoletim = request.IdBoletim,
                IdTurma = request.IdTurma,
                Nota = request.Nota,
            };

            await _notasBoletimRepository.AddAsync(entity);

            return await _unitOfWork.CommitAsync();
        }
    }
}
