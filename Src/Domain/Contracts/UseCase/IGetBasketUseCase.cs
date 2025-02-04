using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Domain.Contracts.UseCase
{
    public interface IGetBasketUseCase
    {
        public Task<Result<string, Exception>> AddAsync(IEnumerable<OrderDetail> order);
        public Task<Result<string, Exception>> UpdateAsync(OrderDetail order);
        public Task<Result<IEnumerable<OrderDetail>, Exception>> GetAsync();
        public Task<Result<OrderDetail, Exception>> GetAsync(OrderDetail order);
        public Task<Result<string, Exception>> ClearAllAsync();
    }
}
