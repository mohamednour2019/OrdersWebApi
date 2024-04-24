using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Core.Domain.RepositoryContracts;
using Orders.Infrastructure.DatabaseContext;

namespace Orders.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        private IDbContextTransaction _dbTransaction;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task BeginTransaction()
        {
            _dbTransaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaciton()
        {
            try
            {
                await Commit();
                await _dbTransaction.CommitAsync();
            }
            catch (Exception ex)
            {

                await RollbackTransaction();
                throw;
            }
        }

        public async Task RollbackTransaction()
        {
            await _dbTransaction.RollbackAsync();
        }


        public void Dispose()
        {
            if( _dbTransaction != null )
            {
                _dbTransaction.Dispose();
            }
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangeAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
