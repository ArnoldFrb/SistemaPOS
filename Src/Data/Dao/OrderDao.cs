using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaPOS.Src.Core.Db;
using SistemaPOS.Src.Domain.Contracts.Dao;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Data.Dao
{
    public class OrderDao(AppDbContext context) : IOrderDao
    {
        private readonly AppDbContext _context = context;

        public async Task AddAsync(Order entity)
        {
            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task AddRangeAsync(IEnumerable<Order> entities)
        {
            throw new NotImplementedException();
        }

        public async Task ClearAllAsync()
        {
            _context.Orders.RemoveRange(_context.Orders);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(List<Order> entities)
        {
            throw new NotImplementedException();
        }

        public async Task EditAsync(Order entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public Task<Order> FindAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> FindBy(Expression<Func<Order, bool>>? filter = null, Func<IQueryable<Order>, IOrderedQueryable<Order>>? orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> FindByAsync(Expression<Func<Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> FindFirstOrDefaultAsync(Expression<Func<Order, bool>> predicate)
        {
            return await _context.Orders.FirstOrDefaultAsync(predicate) ?? throw new Exception("No record found.");
        }

        public async Task<IEnumerable<Order>> GetAllAsync() => await _context.Orders.ToListAsync();
    }
}
