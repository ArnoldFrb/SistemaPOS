using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Data.Models;
using SistemaPOS.Src.Domain.Contracts.Repositories.Api;
using SistemaPOS.Src.Domain.Contracts.Services;

namespace SistemaPOS.Src.Data.Repositories.Api
{
    public class ClientApiRepository(IClientService service) : IClientApiRepository
    {
        private readonly IClientService _service = service;
        public async Task<Result<IEnumerable<ClientResponse>, Exception>> GetAll()
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    var result = await _service.GetAll();
                    return Result<IEnumerable<ClientResponse>, Exception>.Ok(result);
                }
                catch (Exception e)
                {
                    return Result<IEnumerable<ClientResponse>, Exception>.Error(e);
                }
            }
            return Result<IEnumerable<ClientResponse>, Exception>.Error(new Exception("Connection to internet is not available"));
        }
    }
}
