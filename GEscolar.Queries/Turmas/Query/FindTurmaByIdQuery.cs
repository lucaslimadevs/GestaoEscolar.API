using GEscolar.Domain.Entity;
using GEscolar.Domain.ViewModels;
using MediatR;

namespace GEscolar.Queries.Turmas.Query
{
    public class FindTurmaByIdQuery : IRequest<TurmaViewModel>
    {
        public Guid Id { get; set; }
    }
}
