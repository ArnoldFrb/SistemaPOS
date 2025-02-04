using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Domain.Contracts.Repositories.Api;
using SistemaPOS.Src.Domain.Contracts.Repositories.Dao;
using SistemaPOS.Src.Domain.Contracts.UseCase;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Domain.UseCase
{
    public class GetProductUseCase(IProductApiRepository api, IProductDbRepository db) : IGetProductUseCase
    {
        private readonly IProductApiRepository _api = api;
        private readonly IProductDbRepository _db = db;
        public async Task<Result<IEnumerable<Product>, Exception>> GetAll()
        {
            var dbResult = await _db.GetAllAsync();
            if (dbResult.IsOkOrError && dbResult.Unwrap().Any())
            {
                return dbResult;
            }

            var apiResult = await _api.GetAll();
            if (apiResult.IsOkOrError)
            {
                var elements = apiResult.Unwrap().Select(item => item.ToEntity()).ToList();
                var result = await _db.AddRangeAsync(elements);

                return result.IsOkOrError
                    ? Result<IEnumerable<Product>, Exception>.Ok(elements)
                    : Result<IEnumerable<Product>, Exception>.Error(result.UnwrapError());
            }

            return Result<IEnumerable<Product>, Exception>.Error(apiResult.UnwrapError());
        }
    }
}
