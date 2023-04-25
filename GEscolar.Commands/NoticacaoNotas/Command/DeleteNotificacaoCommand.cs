using MediatR;

namespace GEscolar.Commands.NoticacaoNotas.Command
{
    public class DeleteNotificacaoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
