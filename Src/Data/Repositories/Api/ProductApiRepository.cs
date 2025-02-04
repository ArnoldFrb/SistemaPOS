using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Data.Models;
using SistemaPOS.Src.Domain.Contracts.Repositories.Api;
using SistemaPOS.Src.Domain.Contracts.Services;

namespace SistemaPOS.Src.Data.Repositories.Api
{
    public class ProductApiRepository(IProductService service) : IProductApiRepository
    {
        private readonly IProductService _service = service;
        public async Task<Result<IEnumerable<ProductResponse>, Exception>> GetAll()
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    var result = await _service.GetAll();
                    return Result<IEnumerable<ProductResponse>, Exception>.Ok(result);
                }
                catch (Exception e)
                {
                    return Result<IEnumerable<ProductResponse>, Exception>.Error(e);
                }
            }
            return Result<IEnumerable<ProductResponse>, Exception>.Error(new Exception("Connection to internet is not available"));
        }
    }
}
