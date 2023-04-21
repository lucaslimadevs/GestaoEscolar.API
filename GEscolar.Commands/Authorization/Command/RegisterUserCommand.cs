using GEscolar.Domain.Enum;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GEscolar.Commands.Authorization.Command
{
    public class RegisterUserCommand : IRequest<bool>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string ConfirmPassword { get; set; }
        public DateTime DataNascimento { get; set; }
        public ETipo Tipo { get; set; }
    }
}
