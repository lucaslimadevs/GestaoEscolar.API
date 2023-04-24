using MediatR;

namespace GEscolar.Commands.Turmas.Command
{
    public class UpdateTurmaCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdDisciplina { get; set; }
    }
}
