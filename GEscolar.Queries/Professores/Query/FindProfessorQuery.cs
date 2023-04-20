using GEscolar.Domain.Entity;
using MediatR;

namespace GEscolar.Queries.Professores.Query
{
    public class FindProfessorQuery : IRequest<IEnumerable<Professor>>
    {

    }
}
