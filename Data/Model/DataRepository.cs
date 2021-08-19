using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Products.DBContext
{
    public class DataRepository<T> : IRepository<T> where T : class
    {
        protected DbContext Context { get; set; }
        protected DbSet<T> Data { get; set; }

        public DataRepository(DbContext context)
        {
            Context = context;
            Data = context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return Data;
        }

        public IQueryable<T> GetAll<TProperty>(System.Linq.Expressions.Expression<Func<T, TProperty>> path1, System.Linq.Expressions.Expression<Func<T, TProperty>> path2 = null, System.Linq.Expressions.Expression<Func<T, TProperty>> path3 = null, System.Linq.Expressions.Expression<Func<T, TProperty>> path4 = null)
        {
            var d = Data.Include(path1);
            if (path2 != null) d = d.Include(path2);
            if (path3 != null) d = d.Include(path3);
            if (path4 != null) d = d.Include(path4);
            return d;
        }

        public IQueryable<T> GetAllWithNoTracking()
        {
            return Data.AsNoTracking<T>();
        }

        public DbSet<T> GetUnderlyingContextData()
        {
            return Data;
        }

        public void Add(T entity)
        {
            Data.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Data.AddRange(entities);
        }

        public void Delete(T entity)
        {
            Data.Remove(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            Data.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            Data.Update(entity);
        }

    }
}
