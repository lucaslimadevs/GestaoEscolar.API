using GEscolar.API.Infra.SqlServer.Data;
using GEscolar.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GEscolarAPI.Infra.SqlServer.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> DbSet;
        public readonly EscolarDbContext _context;

        public BaseRepository(EscolarDbContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);            
        }

        public async Task AddRangeAsync(TEntity entity)
        {
            await DbSet.AddRangeAsync(entity);
        }

        public void Update(TEntity entity)
        {            
            DbSet.Update(entity);
        }
    }
}
