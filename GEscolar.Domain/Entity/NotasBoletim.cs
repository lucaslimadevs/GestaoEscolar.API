namespace GEscolar.Domain.Entity
{
    public class NotasBoletim : EntityBase
    {
        public Guid IdTurma { get; set; }
        public Guid IdBoletim { get; set; }
        public decimal Nota { get; set; }

        public virtual Turma Turma { get; set; }
        public virtual Boletim Boletim { get; set; }
    }
}
