using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Data.Models;

namespace SistemaPOS.Src.Domain.Contracts.Repositories.Api
{
    public interface IProductApiRepository
    {
        public Task<Result<IEnumerable<ProductResponse>, Exception>> GetAll();
    }
}
