using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaPOS.Src.Core.Db;
using SistemaPOS.Src.Domain.Contracts.Dao;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Data.Dao
{
    public class UserDao(AppDbContext context) : IUserDao
    {
        private readonly AppDbContext _context = context;

        public Task AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }

        public Task ClearAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(List<User> entities)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> FindBy(Expression<Func<User, bool>>? filter = null, Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> FindByAsync(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindFirstOrDefaultAsync(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.FirstOrDefaultAsync(predicate) ?? throw new Exception("No record found.");
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
