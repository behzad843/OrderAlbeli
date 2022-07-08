using Microsoft.EntityFrameworkCore;
using OrderManagement.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using OrderManagement.Repository.UnitOfWork;

namespace OrderManagement.Repository.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        private IUnitOfWork UnitOfWork { get; set; }

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public virtual IQueryable<T> GetQuery()
        {
            return UnitOfWork.DbContext.Set<T>().AsQueryable();
        }

        public IQueryable<TEntity> GetQueryAs<TEntity>()
        {
            return UnitOfWork.DbContext.Set<T>().AsNoTracking().OfType<TEntity>().AsQueryable();
        }

        public virtual IQueryable<T> GetQueryAsTracking()
        {
            return UnitOfWork.DbContext.Set<T>().AsQueryable();
        }

        public virtual async Task<T> Create(T entity)
        {
            return UnitOfWork.DbContext.Set<T>().Add(entity).Entity;
        }

        public virtual async Task Create(ICollection<T> entities)
        {
            await UnitOfWork.DbContext.Set<T>().AddRangeAsync(entities);
        }

        public virtual async Task<T> Update(T entity)
        {
            return UnitOfWork.DbContext.Set<T>().Update(entity).Entity;
        }

        public virtual async Task Update(ICollection<T> entities)
        {
            UnitOfWork.DbContext.Set<T>().UpdateRange(entities);
        }

        public virtual async Task Delete(T entity)
        {
            //UnitOfWork.DbContext.Entry(entity).State = EntityState.Deleted;

            UnitOfWork.DbContext.Set<T>().Remove(entity);
        }

        public virtual async Task Delete(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                UnitOfWork.DbContext.Entry(entity).State = EntityState.Deleted;
            }

            //UnitOfWork.DbContext.Set<T>().RemoveRange(entities);
        }

        public virtual IQueryable<T> FromSql(string query)
        {
            return UnitOfWork.DbContext.Set<T>().FromSqlRaw(query);
        }

        public virtual IQueryable<TEntity> FromSql<TEntity>(string query) where TEntity : class
        {
            return UnitOfWork.DbContext.Set<TEntity>().FromSqlRaw(query);
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    UnitOfWork.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
