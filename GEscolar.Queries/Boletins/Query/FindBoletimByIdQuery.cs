using GEscolar.Domain.Entity;
using GEscolar.Domain.ViewModels;
using MediatR;

namespace GEscolar.Queries.Boletins.Query
{
    public class FindBoletimByIdQuery : IRequest<BoletimViewModel>
    {
        public Guid Id { get; set; }
    }
}
