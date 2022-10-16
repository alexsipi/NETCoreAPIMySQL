using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository.Pattern.Data
{
    internal interface IRepository<T> where T : class
    {
        public void Add(T entity);
        public void Remove(T entity);
        public T Get(Guid id);
        public IEnumerable<T> GetAll();
        public void Udpate(T entity);
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate); // Lambda expression
    }
}
