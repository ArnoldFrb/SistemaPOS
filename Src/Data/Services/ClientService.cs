using SistemaPOS.Src.Core.Api;
using SistemaPOS.Src.Data.Models;
using SistemaPOS.Src.Domain.Contracts.Services;

namespace SistemaPOS.Src.Data.Services
{
    internal class ClientService(IApiUser apiClient) : IClientService
    {

        private readonly IApiUser _apiClient = apiClient;
        public async Task<IEnumerable<ClientResponse>> GetAll()
        {
            var response = await _apiClient.GetUsers();
            if (response.IsSuccessStatusCode)
            {
                return response.Content ?? [];
            }
            throw new Exception(response.Error!.Message, response.Error);
        }
    }
}
