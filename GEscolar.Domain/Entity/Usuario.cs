using GEscolar.Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace GEscolar.Domain.Entity
{
    public class Usuario : IdentityUser<Guid>
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public ETipo Tipo { get; set; }
    }
}

