namespace GEscolar.Domain.ViewModels
{
    public class NotasBoletimViewModel
    {
        public Guid Id { get; set; }
        public Guid IdTurma { get; set; }
        public Guid IdBoletim { get; set; }
        public string NomeDisciplina { get; set; }
        public string NomeUsuario { get; set; }
        public decimal Nota { get; set; }
    }
}
