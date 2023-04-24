using MediatR;

namespace GEscolar.Commands.Turmas.Command
{
    public class DeleteTurmaCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
