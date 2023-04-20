using GEscolar.API.Infra.SqlServer.Data;
using GEscolar.Domain.Entity;
using GEscolar.Domain.Repositories;

namespace GEscolarAPI.Infra.SqlServer.Repositories
{
    public class TurmaRepository : BaseRepository<Turma>, ITurmaRepository
    {
        public TurmaRepository(EscolarDbContext context) : base(context)
        {
        }        
    }
}
