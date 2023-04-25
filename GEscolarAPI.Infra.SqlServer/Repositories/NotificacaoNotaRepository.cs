using GEscolar.API.Infra.SqlServer.Data;
using GEscolar.Domain.Entity;
using GEscolar.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GEscolarAPI.Infra.SqlServer.Repositories
{
    public class NotificacaoNotaRepository : BaseRepository<NotificacaoNota>, INotificacaoNotaRepository
    {
        public NotificacaoNotaRepository(EscolarDbContext context) : base(context)
        {

        }

        public async Task<NotificacaoNota> FindById(Guid id)
        {
            var notificacao = await DbSet
                .FirstOrDefaultAsync(e => e.Id == id && e.Ativo);

            return notificacao ?? new NotificacaoNota();
        }

        public async Task<IEnumerable<NotificacaoNota>> FindByIdUsuario(Guid idUsuario)
            => await DbSet
            .Include(e => e.Usuario)
            .Include(e => e.Disciplina)
            .Where(e => e.IdUsuario == idUsuario &&
                        e.Ativo)
            .ToListAsync();                                
    }
}
