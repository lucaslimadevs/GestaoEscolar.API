using GEscolar.Commands.NotasBoletins.Command;
using GEscolar.Commands.NoticacaoNotas.Command;
using GEscolar.Domain.Entity;
using GEscolar.Domain.Repositories;
using MediatR;

namespace GEscolar.Commands.NotasBoletins.Handle
{
    public class InsertNotasBoletimCommandHandler : IRequestHandler<InsertNotasBoletimCommand, bool>
    {
        private readonly INotasBoletimRepository _notasBoletimRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public InsertNotasBoletimCommandHandler(INotasBoletimRepository notasBoletimRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _notasBoletimRepository = notasBoletimRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
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

            var result = await _unitOfWork.CommitAsync();

            if (result == true)
            {
                await _mediator.Send(new InsertNotificacaoCommand
                {
                    Nota = request.Nota,
                    IdUsuario = request.IdUsuario,
                    IdDisciplina = request.IdDisciplina
                });
            }

            return result;
        }
    }
}
