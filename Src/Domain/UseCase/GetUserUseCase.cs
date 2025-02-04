using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Domain.Contracts.Repositories.Api;
using SistemaPOS.Src.Domain.Contracts.Repositories.Dao;
using SistemaPOS.Src.Domain.Contracts.UseCase;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Domain.UseCase
{
    public class GetUserUseCase(IUserDbRepository db) : IGetUserUseCase
    {
        private readonly IUserDbRepository _db = db;

        public async Task<Result<User, Exception>> AuthAsync(string username, string password)
        {
            return await _db.AuthAsync(username, password);
        }
    }
}
