using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaPOS.Src.Core.Db;
using SistemaPOS.Src.Domain.Contracts.Dao;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Data.Dao
{
    public class ClientDao(AppDbContext context) : IClientDao
    {
        private readonly AppDbContext _context = context;

        public Task AddAsync(Client entity)
        {
            throw new NotImplementedException();
        }

        public async Task AddRangeAsync(IEnumerable<Client> elements)
        {
            await _context.Clients.AddRangeAsync(elements);
            await _context.SaveChangesAsync();
        }

        public async Task ClearAllAsync()
        {
            _context.Clients.RemoveRange(_context.Clients);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Client entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(List<Client> entities)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(Client entity)
        {
            throw new NotImplementedException();
        }

        public Task<Client> FindAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> FindBy(Expression<Func<Client, bool>>? filter = null, Func<IQueryable<Client>, IOrderedQueryable<Client>>? orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> FindByAsync(Expression<Func<Client, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Client> FindFirstOrDefaultAsync(Expression<Func<Client, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Client>> GetAllAsync() => await _context.Clients.ToListAsync();
    }
}
