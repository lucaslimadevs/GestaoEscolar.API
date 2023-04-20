using GEscolar.Domain.Entity;
using MediatR;

namespace GEscolar.Queries.Alunos.Query
{
    public class FindAlunoByIdQuery : IRequest<Aluno>
    {
        public Guid Id { get; set; }
    }
}
