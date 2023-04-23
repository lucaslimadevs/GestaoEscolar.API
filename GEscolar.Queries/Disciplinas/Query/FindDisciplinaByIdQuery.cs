using GEscolar.Domain.Entity;
using MediatR;

namespace GEscolar.Queries.Disciplinas.Query
{
    public class FindDisciplinaByIdQuery : IRequest<Disciplina>
    {
        public Guid Id { get; set; }
    }
}
