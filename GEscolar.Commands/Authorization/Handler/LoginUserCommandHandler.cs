using GEscolar.Commands.Authorization.Command;
using GEscolar.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GEscolar.Commands.Authorization.Handler
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, bool>
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;

        public LoginUserCommandHandler(
            SignInManager<Usuario> signInManager,
            UserManager<Usuario> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, true);

                if (result.Succeeded)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Erro ao efetuar login", ex);
            }

        }
    }
}
