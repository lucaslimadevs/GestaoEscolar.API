using MediatR;

namespace GEscolar.Commands.Boletins.Command
{
    public class InsertBoletimCommand : IRequest<bool>
    {
        public DateTime DataEntrega { get; set; }
        public Guid IdUsuario { get; set; }
    }
}
