using MediatR;

namespace GEscolar.Commands.Boletins.Command
{
    public class UpdateBoletimCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DateTime DataEntrega { get; set; }
        public Guid IdUsuario { get; set; }
    }
}
