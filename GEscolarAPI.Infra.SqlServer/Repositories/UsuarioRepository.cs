using GEscolar.API.Infra.SqlServer.Data;
using GEscolar.Domain.Entity;
using GEscolar.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GEscolarAPI.Infra.SqlServer.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(EscolarDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Usuario>> FindAll()
            => await DbSet.ToListAsync();                                
    }
}
