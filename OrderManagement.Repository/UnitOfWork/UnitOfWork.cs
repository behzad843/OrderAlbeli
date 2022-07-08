using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext DbContext { get; set; }

        public UnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task SaveChanges(DateTime? useTrackableDateTime = null)
        {
            if (DbContext.ChangeTracker.HasChanges())
                await DbContext.SaveChangesAsync();
        }

        public virtual async Task<int> ExecuteSql(string query)
        {
            return await DbContext.Database.ExecuteSqlRawAsync(query);
        }

        public virtual IExecutionStrategy CreateExecutionStrategy()
        {
            return DbContext.Database.CreateExecutionStrategy();
        }

        public void ResetChangeTracker()
        {
            DbContext.ChangeTracker.Entries().ToList().ForEach(x => x.State = EntityState.Detached);
        }

        public async Task DoItTransactional(Func<Task> func)
        {
            await CreateExecutionStrategy().Execute(async () =>
            {
                await using var transaction = await BeginTransaction(IsolationLevel.ReadCommitted);

                await func();

                await SaveChanges();
                await transaction.CommitAsync();
            });
        }
        public async Task<IDbContextTransaction> BeginTransaction(IsolationLevel isolationLevel)
        {
            return await DbContext.Database.BeginTransactionAsync();
        }

        public async Task<T> DoItTransactional<T>(Func<Task<T>> func)
        {
            async Task<T> Convert()
            {
                await using var transaction = await BeginTransaction(IsolationLevel.ReadCommitted);

                var result = await func();

                await SaveChanges();
                await transaction.CommitAsync();
                return result;
            }

            return await CreateExecutionStrategy().Execute(Convert);
        }

        public void Dispose()
        {
            DbContext?.Dispose();
        }
    }
}
