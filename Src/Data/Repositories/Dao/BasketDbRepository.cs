using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Domain.Contracts.Dao;
using SistemaPOS.Src.Domain.Contracts.Repositories.Dao;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Data.Repositories.Dao
{
    public class BasketDbRepository(IBasketDao dao) : IBasketDbRepository
    {
        private readonly IBasketDao _dao = dao;

        public async Task<Result<string, Exception>> AddAsync(IEnumerable<OrderDetail> orders)
        {
            try
            {
                await _dao.AddRangeAsync(orders);
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

        public async Task<Result<IEnumerable<OrderDetail>, Exception>> GetAsync()
        {
            try
            {
                var result = await _dao.GetAllAsync();
                return Result<IEnumerable<OrderDetail>, Exception>.Ok(result);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<OrderDetail>, Exception>.Error(ex);
            }
        }

        public async Task<Result<OrderDetail, Exception>> GetAsync(OrderDetail order)
        {
            try
            {
                var result = await _dao.FindFirstOrDefaultAsync(item => item.ProductId == order.ProductId);
                return Result<OrderDetail, Exception>.Ok(result);
            }
            catch (Exception ex)
            {
                return Result<OrderDetail, Exception>.Error(ex);
            }
        }

        public async Task<Result<string, Exception>> UpdateAsync(OrderDetail order)
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
