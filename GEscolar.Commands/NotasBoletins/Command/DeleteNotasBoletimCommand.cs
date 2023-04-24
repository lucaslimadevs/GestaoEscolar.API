using MediatR;

namespace GEscolar.Commands.NotasBoletins.Command
{
    public class DeleteNotasBoletimCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
