using System;

namespace GEscolar.Domain.Entity
{
    public class Professor : EntityBase
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }

        public virtual ICollection<Turma> Turmas { get; set; }
    }
}
