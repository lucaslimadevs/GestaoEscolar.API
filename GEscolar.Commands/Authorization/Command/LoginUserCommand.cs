using MediatR;

namespace GEscolar.Commands.Authorization.Command
{
    public class LoginUserCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
