using GEscolar.Domain.Entity;
using MediatR;

namespace GEscolar.Commands.Alunos.Command
{
    public class DeleteAlunoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
