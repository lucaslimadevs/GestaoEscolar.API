using MediatR;

namespace GEscolar.Commands.Boletins.Command
{
    public class DeleteBoletimCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
