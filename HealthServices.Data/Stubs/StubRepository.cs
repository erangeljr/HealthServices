using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using HealthServices.Domain.Interfaces;
using System.Reflection;
using HealthServices.Domain.Models;

namespace HealthServices.Data.Stubs
{
    public class StubRepository<T> : IRepository<T> where T : class
    {
        private readonly List<T> _list;

        public StubRepository(List<T> list)
        {
            _list = list;
        }

        #region IRepository<T> implementation

        public virtual IQueryable<T> AsQueryable()
        {
            return _list.AsQueryable();
        }

        public IEnumerable<T> GetAll()
        {
            return _list;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _list.AsQueryable().Where(predicate);
        }

        public T Single(Expression<Func<T, bool>> predicate)
        {
            return _list.AsQueryable().Single(predicate);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _list.AsQueryable().SingleOrDefault(predicate);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return _list.AsQueryable().First(predicate);
        }

        public T GetById(object id)
        {
            T itemSearched = null;
            PropertyInfo propertyInfo = this.GetPropertyId(typeof(T));

            foreach (var item in _list)
            {
                object itemId = propertyInfo.GetValue(item, null);


                if (itemId is Int32)
                {
                    if ((int)itemId == (int)id)
                    {
                        itemSearched = item;
                        break;
                    }
                }


                if (itemId is Byte)
                {
                    if (Convert.ToByte(itemId) == Convert.ToByte(id))
                    {
                        itemSearched = item;
                        break;
                    }
                }

                if (itemId is String)
                {
                    if (itemId.ToString() == id.ToString())
                    {
                        itemSearched = item;
                        break;
                    }
                }
            }

            return itemSearched;

        }

        public void Add(T entity)
        {
            PropertyInfo propertyInfo = this.GetPropertyId(typeof(T));

            if (propertyInfo.PropertyType.Name == "Int32")
            {
                propertyInfo.SetValue(entity, (_list.Count + 1), null);
            }

            if (propertyInfo.PropertyType.Name == "Byte")
            {
                propertyInfo.SetValue(entity, (Convert.ToByte(_list.Count + 1)), null);
            }

            _list.Add(entity);

            UpdateReferences(entity);
        }

        public void Delete(T entity)
        {
            _list.Remove(entity);
        }

        public void Attach(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            PropertyInfo propertyInfo = this.GetPropertyId(typeof(T));

            object id = propertyInfo.GetValue(entity, null);

            T entityToUpdate = this.GetById(id);

            entityToUpdate = entity;
        }

        #endregion

        private PropertyInfo GetPropertyId(Type type)
        {
            PropertyInfo propertyInfo = null;
            if (typeof(T) == typeof(Person))
            {
                propertyInfo = typeof(Person).GetProperty("PersonId");
            }
         
            if (propertyInfo == null)
            {
                throw new NullReferenceException("Property info missing for InMemoryGenricRepository.cs");
            }

            return propertyInfo;
        }

        private void UpdateReferences(T entity)
        {
            if (typeof(T) == typeof(Person))
            {
                PropertyInfo propertyInfo = null;

                propertyInfo = typeof(Person).GetProperty("PersonId");
                object parentId = propertyInfo.GetValue(entity, null);

            }
        }


        public IEnumerable<T> FindWithChildren(Expression<Func<T, bool>> predicate, string[] children)
        {
            return _list.AsQueryable().Where(predicate);
        }
    }
}
