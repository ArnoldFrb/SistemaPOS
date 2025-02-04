using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaPOS.Src.Core.Db;
using SistemaPOS.Src.Domain.Contracts.Dao;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Data.Dao
{
    public class BasketDao(AppDbContext context) : IBasketDao
    {
        private readonly AppDbContext _context = context;

        public Task AddAsync(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public async Task AddRangeAsync(IEnumerable<OrderDetail> entities)
        {
            await _context.OrderDetails.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task ClearAllAsync()
        {
            _context.OrderDetails.RemoveRange(_context.OrderDetails);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(List<OrderDetail> entities)
        {
            throw new NotImplementedException();
        }

        public async Task EditAsync(OrderDetail entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public Task<OrderDetail> FindAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDetail>> FindBy(Expression<Func<OrderDetail, bool>>? filter = null, Func<IQueryable<OrderDetail>, IOrderedQueryable<OrderDetail>>? orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDetail>> FindByAsync(Expression<Func<OrderDetail, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderDetail> FindFirstOrDefaultAsync(Expression<Func<OrderDetail, bool>> predicate)
        {
            return await _context.OrderDetails.FirstOrDefaultAsync(predicate) ?? throw new Exception("No record found.");
        }

        public async Task<IEnumerable<OrderDetail>> GetAllAsync() => await _context.OrderDetails.ToListAsync();
    }
}
