using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Domain.Contracts.Repositories.Dao;
using SistemaPOS.Src.Domain.Contracts.UseCase;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Domain.UseCase
{
    public class GetBasketUseCase(IBasketDbRepository db) : IGetBasketUseCase
    {
        private readonly IBasketDbRepository _db = db;

        public Task<Result<string, Exception>> AddAsync(IEnumerable<OrderDetail> orders)
        {
            return _db.AddAsync(orders);
        }

        public Task<Result<string, Exception>> ClearAllAsync()
        {
            return _db.ClearAllAsync();
        }

        public Task<Result<IEnumerable<OrderDetail>, Exception>> GetAsync()
        {
            return _db.GetAsync();
        }

        public Task<Result<OrderDetail, Exception>> GetAsync(OrderDetail order)
        {
            return _db.GetAsync(order);
        }

        public Task<Result<string, Exception>> UpdateAsync(OrderDetail order)
        {
            return _db.UpdateAsync(order);
        }
    }
}
