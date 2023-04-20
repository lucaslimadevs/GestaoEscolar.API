using MediatR;

namespace GEscolar.Commands.Professores.Command
{
    public class DeleteProfessorCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
