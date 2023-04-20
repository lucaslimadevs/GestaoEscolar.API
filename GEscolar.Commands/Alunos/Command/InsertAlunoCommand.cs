using MediatR;

namespace GEscolar.Commands.Alunos.Command
{
    public class InsertAlunoCommand : IRequest<bool>
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
    }
}
