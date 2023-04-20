using GEscolar.API.Infra.SqlServer.Data;
using GEscolar.Domain.Entity;
using GEscolar.Domain.Repositories;

namespace GEscolarAPI.Infra.SqlServer.Repositories
{
    public class NotasBoletimRepository : BaseRepository<NotasBoletim>, INotasBoletimRepository
    {
        public NotasBoletimRepository(EscolarDbContext context) : base(context)
        {
        }        
    }
}
