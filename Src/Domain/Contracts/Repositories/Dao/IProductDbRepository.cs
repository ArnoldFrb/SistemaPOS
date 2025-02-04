using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Domain.Contracts.Repositories.Dao
{
    public interface IProductDbRepository
    {
        public Task<Result<IEnumerable<Product>, Exception>> GetAllAsync();
        public Task<Result<string, Exception>> AddRangeAsync(IEnumerable<Product> elements);
    }
}
