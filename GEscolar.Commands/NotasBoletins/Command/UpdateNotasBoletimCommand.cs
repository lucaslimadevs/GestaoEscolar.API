using MediatR;

namespace GEscolar.Commands.NotasBoletins.Command
{
    public class UpdateNotasBoletimCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid IdTurma { get; set; }
        public Guid IdBoletim { get; set; }
        public decimal Nota { get; set; }
    }
}
