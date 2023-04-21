namespace GEscolar.Domain.Entity
{
    public class Boletim : EntityBase
    {
        public DateTime DataEntrega { get; set; }
        public Guid IdUsuario { get; set; }


        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<NotasBoletim> NotasBoletins { get; set; }
    }
}
