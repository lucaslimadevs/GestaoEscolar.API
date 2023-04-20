using MediatR;

namespace GEscolar.Commands.Alunos.Command
{
    public class UpdateAlunoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
    }
}
