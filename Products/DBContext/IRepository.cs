using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.DBContext
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetAllWithNoTracking();

        IQueryable<T> GetAll<TProperty>(System.Linq.Expressions.Expression<Func<T, TProperty>> path1, System.Linq.Expressions.Expression<Func<T, TProperty>> path2 = null, System.Linq.Expressions.Expression<Func<T, TProperty>> path3 = null, System.Linq.Expressions.Expression<Func<T, TProperty>> path4 = null);

        DbSet<T> GetUnderlyingContextData();

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Update(T entity);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);
    }
}
