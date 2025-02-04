using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaPOS.Src.Core.Db;
using SistemaPOS.Src.Domain.Contracts.Dao;
using SistemaPOS.Src.Domain.Contracts.Dao.Base;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Data.Dao
{
    public class ProductDao(AppDbContext context) : IProductDao
    {
        private readonly AppDbContext _context = context;

        public Task AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task AddRangeAsync(IEnumerable<Product> elements)
        {
            await _context.Products.AddRangeAsync(elements);
            await _context.SaveChangesAsync();
        }

        public async Task ClearAllAsync()
        {
            _context.Products.RemoveRange(_context.Products);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(List<Product> entities)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> FindAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> FindBy(Expression<Func<Product, bool>>? filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> FindByAsync(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Product> FindFirstOrDefaultAsync(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync() => await _context.Products.ToListAsync();
    }
}
