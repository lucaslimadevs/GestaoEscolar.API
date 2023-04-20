using GEscolar.API.Infra.SqlServer.Data;
using GEscolar.Domain.Entity;
using GEscolar.Domain.Repositories;

namespace GEscolarAPI.Infra.SqlServer.Repositories
{
    public class BoletimRepository : BaseRepository<Boletim>, IBoletimRepository
    {
        public BoletimRepository(EscolarDbContext context) : base(context)
        {
        }        
    }
}
