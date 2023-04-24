namespace GEscolar.Domain.ViewModels
{
    public class TurmaViewModel
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Tipo { get; set; }
        public Guid IdDisciplina { get; set; }
        public string NomeDisciplina { get; set; }
    }
}
