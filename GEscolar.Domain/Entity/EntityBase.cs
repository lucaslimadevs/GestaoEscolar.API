namespace GEscolar.Domain.Entity
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; } = true;

        public void Delete()
        {
            Ativo = false;
        }
    }
}
