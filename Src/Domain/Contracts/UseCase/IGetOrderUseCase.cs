using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Domain.Contracts.UseCase
{
    public interface IGetOrderUseCase
    {
        public Task<Result<string, Exception>> AddAsync(Order order);
        public Task<Result<string, Exception>> UpdateAsync(Order order);
        public Task<Result<IEnumerable<Order>, Exception>> GetAsync();
        public Task<Result<Order, Exception>> GetAsync(Order order);
        public Task<Result<string, Exception>> ClearAllAsync();
    }
}
