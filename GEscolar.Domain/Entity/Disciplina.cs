namespace GEscolar.Domain.Entity
{
    public class Disciplina : EntityBase
    {
        public string Nome { get; set; } = string.Empty;
        public string CargaHoraria { get; set; } = string.Empty;

        public virtual ICollection<Turma> Turmas { get; set; }
        public virtual ICollection<NotificacaoNota> NotificacaoNotas { get; set; }
    }
}
