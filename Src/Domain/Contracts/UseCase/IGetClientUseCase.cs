using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Domain.Contracts.UseCase
{
    public interface IGetClientUseCase
    {
        public Task<Result<IEnumerable<Client>, Exception>> GetAll();
    }
}
