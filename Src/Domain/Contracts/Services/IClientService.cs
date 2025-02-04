using SistemaPOS.Src.Data.Models;

namespace SistemaPOS.Src.Domain.Contracts.Services
{
    public interface IClientService
    {
        public Task<IEnumerable<ClientResponse>> GetAll();
    }
}
