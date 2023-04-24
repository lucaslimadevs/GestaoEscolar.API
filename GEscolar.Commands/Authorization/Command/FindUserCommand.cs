using GEscolar.Domain.Entity;
using GEscolar.Domain.ViewModels;
using MediatR;

namespace GEscolar.Commands.Authorization.Command
{
    public class FindUserCommand : IRequest<IEnumerable<UsuarioViewModel>>
    {
    }
}
