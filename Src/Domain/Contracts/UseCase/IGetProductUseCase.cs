using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Domain.Contracts.UseCase
{
    public interface IGetProductUseCase
    {
        public Task<Result<IEnumerable<Product>, Exception>> GetAll();
    }
}
