using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OrderManagement.Repository.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetQuery();
        IQueryable<TEntity> GetQueryAs<TEntity>();
        IQueryable<T> GetQueryAsTracking();
        Task<T> Create(T entity);
        Task Create(ICollection<T> entities);
        Task<T> Update(T entity);
        Task Update(ICollection<T> entities);
        Task Delete(T entity);
        Task Delete(ICollection<T> entities);
        IQueryable<T> FromSql(string query);
        IQueryable<TEntity> FromSql<TEntity>(string query) where TEntity : class;
    }
}
