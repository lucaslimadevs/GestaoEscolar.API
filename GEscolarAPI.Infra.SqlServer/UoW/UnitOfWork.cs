using GEscolar.API.Infra.SqlServer.Data;
using GEscolar.Domain.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace GEscolarAPI.Infra.SqlServer.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EscolarDbContext _context;

        public UnitOfWork(EscolarDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
