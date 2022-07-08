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
    public interface IUnitOfWork : IDisposable
    {
        DbContext DbContext { get; }
        Task SaveChanges(DateTime? useTrackableDateTime = null);
        Task<int> ExecuteSql(string query);
        Task DoItTransactional(Func<Task> func);
        Task<T> DoItTransactional<T>(Func<Task<T>> func);

        Task<IDbContextTransaction> BeginTransaction(IsolationLevel isolationLevel);
    }
}
