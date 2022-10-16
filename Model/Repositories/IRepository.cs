using System.Linq.Expressions;

namespace NetCoreAPIMySQL.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        public Task<bool> Insert(T entity);
        public Task<bool> Delete(int id);
        public Task<T> Get(int id);
        public Task<IEnumerable<T>> GetAll();
        public Task<bool> Update(T entity);
        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate); // Lambda expression
    }
}
