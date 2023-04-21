using MediatR;

namespace GEscolar.Commands.Authorization.Command
{
    public class RegisterUserCommand : IRequest<bool>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DataNascimento { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
