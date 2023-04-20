using MediatR;

namespace GEscolar.Commands.Professores.Command
{
    public class InsertProfessorCommand : IRequest<bool>
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }        
    }
}
