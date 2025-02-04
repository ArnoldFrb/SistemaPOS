using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Domain.Contracts.Repositories.Dao;
using SistemaPOS.Src.Domain.Contracts.UseCase;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Domain.UseCase
{
    public class GetOrderUseCase(IOrderDbRepository db) : IGetOrderUseCase
    {
        private readonly IOrderDbRepository _db = db;

        public async Task<Result<string, Exception>> AddAsync(Order order)
        {
            var result = await _db.GetAsync(order);
            if (result.IsOkOrError) 
            {
                return await _db.UpdateAsync(order);
            } 
            else
            {
                return await _db.AddAsync(order);
            }
        }

        public Task<Result<string, Exception>> ClearAllAsync()
        {
            return _db.ClearAllAsync();
        }

        public Task<Result<IEnumerable<Order>, Exception>> GetAsync()
        {
            return _db.GetAsync();
        }

        public Task<Result<Order, Exception>> GetAsync(Order order)
        {
            return _db.GetAsync(order);
        }

        public Task<Result<string, Exception>> UpdateAsync(Order order)
        {
            return _db.UpdateAsync(order);
        }
    }
}
