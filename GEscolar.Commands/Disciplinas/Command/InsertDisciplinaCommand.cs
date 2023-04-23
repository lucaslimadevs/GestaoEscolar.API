using MediatR;

namespace GEscolar.Commands.Disciplinas.Command
{
    public class InsertDisciplinaCommand : IRequest<bool>
    {
        public string Nome { get; set; } = string.Empty;
        public string CargaHoraria { get; set; } = string.Empty;
    }
}
