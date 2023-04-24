namespace GEscolar.Domain.Entity
{
    public class NotificacaoNota : EntityBase
    {
        public Guid IdUsuario { get; set; }
        public Guid IdDisciplina { get; set; }
        public decimal Nota { get; set; }

        public virtual Disciplina Disciplina { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
