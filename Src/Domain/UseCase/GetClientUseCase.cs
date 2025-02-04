using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Domain.Contracts.Repositories.Api;
using SistemaPOS.Src.Domain.Contracts.Repositories.Dao;
using SistemaPOS.Src.Domain.Contracts.UseCase;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Domain.UseCase
{
    public class GetClientUseCase(IClientApiRepository api, IClientDbRepository db) : IGetClientUseCase
    {
        private readonly IClientApiRepository _api = api;
        private readonly IClientDbRepository _db = db;
        public async Task<Result<IEnumerable<Client>, Exception>> GetAll()
        {
            var dbResult = await _db.GetAllAsync();
            if (dbResult.IsOkOrError && dbResult.Unwrap().Any())
            {
                return dbResult;
            }

            var apiResult = await _api.GetAll();
            if (apiResult.IsOkOrError)
            {
                var elemets = apiResult.Unwrap().Select(item => item.ToEntity()).ToList();
                var result = await _db.AddRangeAsync(elemets);

                return result.IsOkOrError
                    ? Result<IEnumerable<Client>, Exception>.Ok(elemets)
                    : Result<IEnumerable<Client>, Exception>.Error(result.UnwrapError());
            }

            return Result<IEnumerable<Client>, Exception>.Error(apiResult.UnwrapError());
        }
    }
}
