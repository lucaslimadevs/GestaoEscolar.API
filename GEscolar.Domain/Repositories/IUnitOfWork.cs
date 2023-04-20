using Microsoft.EntityFrameworkCore.Storage;

namespace GEscolar.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
        void Dispose();
        IDbContextTransaction BeginTransaction();
    }
}
