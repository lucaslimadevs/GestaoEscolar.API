using GEscolar.Domain.Entity;
using MediatR;

namespace GEscolar.Queries.Professores.Query
{
    public class FindProfessorByIdQuery : IRequest<Professor>
    {
        public Guid Id { get; set; }
    }
}
