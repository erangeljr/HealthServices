using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HealthServices.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Returns all entities
        /// </summary>
        /// <returns>Queryable collection of all entities</returns>
        IQueryable<T> GetAsQueryable();

        /// <summary>
        /// Returns all entities in the table.
        /// </summary>
        /// <returns>Enumerable collection of all entities in a table.</returns>
        IEnumerable<T> GetAll();
        
        /// <summary>
        /// Returns entities that match a specific expression condition.
        /// </summary>
        /// <param name="predicate">Predicate function to test each entity.</param>
        /// <returns>Enumerable collection of all entities that match expression.</returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
      
        /// <summary>
        /// Returns the Single entity that matches a specific expression condition.
        /// </summary>
        /// <param name="predicate">Predicate function to test each entity</param>
        /// <returns>Single entity found.</returns>
        T Single(Expression<Func<T, bool>> predicate);
        
        /// <summary>
        /// Returns the Single or Defaultentity that matches a specific expression condition.
        /// </summary>
        /// <param name="predicate">Predicate function to test each entity</param>
        /// <returns>Single or Default entity found.</returns>
        T SingleOrDefault(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Returns the first entity that matches a specific expression condition.
        /// </summary>
        /// <param name="predicate">Predicate function to test each entity</param>
        /// <returns>First entity found.</returns>
        T First(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 	Returns an entity based on its primary key value.
        /// </summary>
        /// <param name="id"> value of the entity's primary key column</param>
        /// <returns>Entity object</returns>
        T GetById(object id);

        /// <summary>
        /// Adds an entity to the data context; to be inserted into the database.
        /// </summary>
        /// <param name="entity">Entity to add.</param>
        void Add(T entity);

        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <param name="entity">Entity to be deleted.</param>
        void Delete(T entity);

        /// <summary>
        /// Attach an entity
        /// </summary>
        /// <param name="entity">Entity to Attach</param>
        void Attach(T entity);

        /// <summary>
        /// Updates an entity in the database
        /// </summary>
        /// <param name="entity">Entity to Update</param>
        void Update(T entity);
    }
}
