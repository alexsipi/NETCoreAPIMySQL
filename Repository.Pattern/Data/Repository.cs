using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.Pattern.Data
{
    // where T: IComparable
    // where T: Product
    // where T: struct
    // where T: class
    // where T: new()
    internal class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context) {
            Context = context;
        }

        public void Add(T entity) {
            Context.Set<T>().Add(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate) {
            return Context.Set<T>().Where(predicate);
        }

        public T Get(Guid id) {
            return Context.Set<T>().Find(id);
        }
        public IEnumerable<T> GetAll() {
            return Context.Set<T>().ToList();
        }

        public void Remove(T entity) {
            Context.Set<T>().Remove(entity);
        }

        public void Udpate(T entity) {
            throw new NotImplementedException();
        }
    }
}
