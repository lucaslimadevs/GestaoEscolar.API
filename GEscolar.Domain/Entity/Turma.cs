namespace GEscolar.Domain.Entity
{
    public class Turma : EntityBase
    {
        public Guid IdUsuario { get; set; }
        public Guid IdDisciplina { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public virtual ICollection<NotasBoletim> NotasBoletins { get; set; }
    }
}
