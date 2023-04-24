using GEscolar.Commands.Authorization.Command;
using GEscolar.Domain.Entity;
using GEscolar.Domain.Repositories;
using GEscolar.Domain.ViewModels;
using MediatR;

namespace GEscolar.Commands.Authorization.Handler
{
    public class FindUserCommandHandler : IRequestHandler<FindUserCommand, IEnumerable<UsuarioViewModel>>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public FindUserCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<UsuarioViewModel>> Handle(FindUserCommand request, CancellationToken cancellationToken)
        { 
            var usuarios = await _usuarioRepository.FindAll();            

            var result = usuarios.AsQueryable().Select(p => new UsuarioViewModel
            {
                Id = p.Id,
                Nome = p.Nome,
                Tipo = p.Tipo.ToString()
            });

            return result;
        }
    }
}
