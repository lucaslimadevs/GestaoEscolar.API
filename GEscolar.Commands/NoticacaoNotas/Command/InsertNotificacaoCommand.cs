using MediatR;

namespace GEscolar.Commands.NoticacaoNotas.Command
{
    public class InsertNotificacaoCommand : IRequest<bool>
    {
        public Guid IdUsuario { get; set; }
        public Guid IdDisciplina { get; set; }
        public decimal Nota { get; set; }
    }
}
