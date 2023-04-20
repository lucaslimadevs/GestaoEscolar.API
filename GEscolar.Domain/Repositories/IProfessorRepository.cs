using GEscolar.Domain.Entity;

namespace GEscolar.Domain.Repositories
{
    public interface IProfessorRepository : IBaseRepository<Professor>
    {
        Task<IEnumerable<Professor>> FindAllProfessores();
        Task<Professor> FindById(Guid id);
    }
}
