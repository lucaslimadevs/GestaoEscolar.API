namespace GEscolar.Domain.Entity
{
    public class Boletim : EntityBase
    {
        public DateTime DataEntrega { get; set; }
        public Guid IdAluno { get; set; }


        public virtual Aluno Aluno { get; set; }
        public virtual ICollection<NotasBoletim> NotasBoletins { get; set; }
    }
}
