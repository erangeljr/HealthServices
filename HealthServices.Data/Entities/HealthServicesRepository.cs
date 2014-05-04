using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using HealthServices.Domain.Interfaces;

namespace HealthServices.Data.Entities
{
  

    public class HealthServicesRepository<T> : IRepository<T> where T : class
    {
       /// <summary>
        /// Represents an entity set that is used to perform create, read, update, and delete operations
        /// 
        /// http://msdn.microsoft.com/en-us/library/system.data.entity.dbset(v=vs.113).aspx
        /// 
        /// </summary>
        private readonly DbSet<T> _dbSet;

        /// <summary>
        /// A DbContext instance represents a combination of the Unit Of Work and Repository patterns such that it can be used to query from a database and 
        /// group together changes that will then be written back to the store as a unit. DbContext is conceptually similar to ObjectContext.
        /// 
        /// http://msdn.microsoft.com/en-us/library/system.data.entity.dbcontext(v=vs.113).aspx
        /// 
        /// </summary>
        private readonly DbContext _dbContext;

        /// <summary>
        /// Default constructor for Entity Repository
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="dbSet"></param>
        public HealthServicesRepository(DbContext dbContext, DbSet<T> dbSet)
        {
            _dbContext = dbContext;
            _dbSet = dbSet;
        }

        /// <summary>
        /// The IQueryable element type
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        /// <summary>
        /// Returns an IEnumerator<T> which when enumerated will execute the query against the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T Single(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Single(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.SingleOrDefault(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T First(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.First(predicate);
        }

        /// <summary>
        /// Uses the primary key value to attempt to find an entity tracked by the context. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Adds the given entity to the context
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// Marks the given entity as Deleted.
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// Marks the given entities as Deleted.
        /// </summary>
        /// <param name="entities"></param>
        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                _dbSet.Remove(entity);
        }

        /// <summary>
        /// Attaches the given entity to the context in the Unchanged
        /// </summary>
        /// <param name="entity"></param>
        public void Attach(T entity)
        {
            _dbSet.Attach(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        

    }
}
