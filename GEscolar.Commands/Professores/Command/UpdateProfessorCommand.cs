using MediatR;

namespace GEscolar.Commands.Professores.Command
{
    public class UpdateProfessorCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }        
    }
}
