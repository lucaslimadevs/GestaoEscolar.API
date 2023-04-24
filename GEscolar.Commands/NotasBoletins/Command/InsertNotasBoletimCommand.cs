using MediatR;

namespace GEscolar.Commands.NotasBoletins.Command
{
    public class InsertNotasBoletimCommand : IRequest<bool>
    {
        public Guid IdTurma { get; set; }
        public Guid IdBoletim { get; set; }
        public decimal Nota { get; set; }
    }
}
