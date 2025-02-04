using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Domain.Contracts.Repositories.Dao
{
    public interface IUserDbRepository
    {
        public Task<Result<User, Exception>> AuthAsync(string username, string password);
    }
}
