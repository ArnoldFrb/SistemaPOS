using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Domain.Contracts.UseCase
{
    public interface IGetUserUseCase
    {
        public Task<Result<User, Exception>> AuthAsync(string username, string password);
    }
}
