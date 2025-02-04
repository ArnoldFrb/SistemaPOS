using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Domain.Contracts.Dao;
using SistemaPOS.Src.Domain.Contracts.Repositories.Dao;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Data.Repositories.Dao
{
    public class OrderDbRepository(IOrderDao dao) : IOrderDbRepository
    {
        private readonly IOrderDao _dao = dao;

        public async Task<Result<string, Exception>> AddAsync(Order order)
        {
            try
            {
                await _dao.AddAsync(order);
                return Result<string, Exception>.Ok("Success");
            }
            catch (Exception ex) 
            {
                return Result<string, Exception>.Error(ex);
            }
        }

        public async Task<Result<string, Exception>> ClearAllAsync()
        {
            try
            {
                await _dao.ClearAllAsync();
                return Result<string, Exception>.Ok("Success");
            }
            catch (Exception ex)
            {
                return Result<string, Exception>.Error(ex);
            }
        }

        public async Task<Result<IEnumerable<Order>, Exception>> GetAsync()
        {
            try
            {
                var result = await _dao.GetAllAsync();
                return Result<IEnumerable<Order>, Exception>.Ok(result);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<Order>, Exception>.Error(ex);
            }
        }

        public async Task<Result<Order, Exception>> GetAsync(Order order)
        {
            try
            {
                var result = await _dao.FindFirstOrDefaultAsync(item => item.Id == order.Id);
                return Result<Order, Exception>.Ok(result);
            }
            catch (Exception ex)
            {
                return Result<Order, Exception>.Error(ex);
            }
        }

        public async Task<Result<string, Exception>> UpdateAsync(Order order)
        {
            try
            {
                await _dao.AddAsync(order);
                return Result<string, Exception>.Ok("Success");
            }
            catch (Exception ex)
            {
                return Result<string, Exception>.Error(ex);
            }
        }
    }
}
