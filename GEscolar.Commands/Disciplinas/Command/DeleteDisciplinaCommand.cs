using GEscolar.Domain.Entity;
using MediatR;

namespace GEscolar.Commands.Disciplinas.Command
{
    public class DeleteDisciplinaCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
