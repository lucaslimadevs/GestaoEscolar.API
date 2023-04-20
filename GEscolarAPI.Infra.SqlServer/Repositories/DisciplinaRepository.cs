using GEscolar.API.Infra.SqlServer.Data;
using GEscolar.Domain.Entity;
using GEscolar.Domain.Repositories;

namespace GEscolarAPI.Infra.SqlServer.Repositories
{
    public class DisciplinaRepository : BaseRepository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(EscolarDbContext context) : base(context)
        {
        }        
    }
}
