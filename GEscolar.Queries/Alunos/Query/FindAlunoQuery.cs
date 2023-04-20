using GEscolar.Domain.Entity;
using MediatR;

namespace GEscolar.Queries.Alunos.Query
{
    public class FindAlunoQuery : IRequest<IEnumerable<Aluno>>
    {
    }
}
