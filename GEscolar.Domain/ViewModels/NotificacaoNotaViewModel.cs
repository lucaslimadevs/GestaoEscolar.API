using GEscolar.Domain.Entity;

namespace GEscolar.Domain.ViewModels
{
    public class NotificacaoNotaViewModel
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdDisciplina { get; set; }
        public decimal Nota { get; set; }
        public string NomeUsuario { get; set; }
        public string NomeDisciplina { get; set; }
    }
}
