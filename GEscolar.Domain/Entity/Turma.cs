namespace GEscolar.Domain.Entity
{
    public class Turma : EntityBase
    {
        public Guid IdProfessor { get; set; }
        public Guid IdAluno { get; set; }
        public Guid IdDisciplina { get; set; }

        public virtual Professor Professor { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public virtual ICollection<NotasBoletim> NotasBoletins { get; set; }
    }
}
