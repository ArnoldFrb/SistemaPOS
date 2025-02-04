using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Data.Models;

namespace SistemaPOS.Src.Domain.Contracts.Repositories.Api
{
    public interface IClientApiRepository
    {
        public Task<Result<IEnumerable<ClientResponse>, Exception>> GetAll();
    }
}
