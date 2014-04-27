using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HealthServices.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAsQueryable();

        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T Single(Expression<Func<T, bool>> predicate);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
        T First(Expression<Func<T, bool>> predicate);
        T GetById(object id);

        void Add(T entity);
        void Delete(T entity);
        void Attach(T entity);
        void Update(T entity);
    }
}
