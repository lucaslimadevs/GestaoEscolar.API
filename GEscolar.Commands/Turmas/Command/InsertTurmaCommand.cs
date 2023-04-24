using MediatR;

namespace GEscolar.Commands.Turmas.Command
{
    public class InsertTurmaCommand : IRequest<bool>
    {
        public Guid IdUsuario { get; set; }
        public Guid IdDisciplina { get; set; }
    }
}
