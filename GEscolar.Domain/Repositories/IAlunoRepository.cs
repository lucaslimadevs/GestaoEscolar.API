using GEscolar.Domain.Entity;

namespace GEscolar.Domain.Repositories
{
    public interface IAlunoRepository : IBaseRepository<Aluno>
    {
        Task<IEnumerable<Aluno>> FindAllAlunos();
        Task<Aluno> FindById(Guid id);
    }
}
