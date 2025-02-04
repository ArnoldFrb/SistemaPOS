using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Domain.Contracts.Repositories.Dao
{
    public interface IClientDbRepository
    {
        public Task<Result<IEnumerable<Client>, Exception>> GetAllAsync();
        public Task<Result<string, Exception>> AddRangeAsync(IEnumerable<Client> elements);
    }
}
