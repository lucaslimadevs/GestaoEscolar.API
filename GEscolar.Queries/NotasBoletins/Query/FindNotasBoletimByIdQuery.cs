using GEscolar.Domain.ViewModels;
using MediatR;

namespace GEscolar.Queries.NotasBoletins.Query
{
    public class FindNotasBoletimByIdQuery : IRequest<NotasBoletimViewModel>
    {
        public Guid Id { get; set; }
    }
}
