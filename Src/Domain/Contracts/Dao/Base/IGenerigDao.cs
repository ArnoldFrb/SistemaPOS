using System.Linq.Expressions;

namespace SistemaPOS.Src.Domain.Contracts.Dao.Base
{
    public interface IGenericDao<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task AddRangeAsync(IEnumerable<T> entities);
        public Task ClearAllAsync();
        public Task<T> FindAsync(object id);
        public Task AddAsync(T entity);
        public Task DeleteAsync(T entity);
        public Task EditAsync(T entity);
        public Task DeleteRangeAsync(List<T> entities);
        public Task<T> FindFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        public Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        public Task<IEnumerable<T>> FindBy(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>,
            IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = ""
         );
    }
}
