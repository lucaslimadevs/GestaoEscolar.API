namespace GEscolar.Domain.ViewModels
{
    public class BoletimViewModel
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime DataEntrega { get; set; }
    }
}
