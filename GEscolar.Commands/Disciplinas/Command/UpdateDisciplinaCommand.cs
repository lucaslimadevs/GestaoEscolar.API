using MediatR;

namespace GEscolar.Commands.Disciplinas.Command
{
    public class UpdateDisciplinaCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CargaHoraria { get; set; } = string.Empty;
    }
}
