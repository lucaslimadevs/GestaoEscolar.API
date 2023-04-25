using MediatR;

namespace GEscolar.Commands.NotasBoletins.Command
{
    public class InsertNotasBoletimCommand : IRequest<bool>
    {
        public Guid IdTurma { get; set; }
        public Guid IdBoletim { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdDisciplina { get; set; }
        public decimal Nota { get; set; }
    }
}
