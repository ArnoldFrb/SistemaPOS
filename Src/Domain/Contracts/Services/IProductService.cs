using SistemaPOS.Src.Data.Models;

namespace SistemaPOS.Src.Domain.Contracts.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductResponse>> GetAll();
    }
}
