using SistemaPOS.Src.Core.Api;
using SistemaPOS.Src.Data.Models;
using SistemaPOS.Src.Domain.Contracts.Services;

namespace SistemaPOS.Src.Data.Services
{
    internal class ProductService(IApiProduct apiClient) : IProductService
    {

        private readonly IApiProduct _apiClient = apiClient;
        public async Task<IEnumerable<ProductResponse>> GetAll()
        {
            var response = await _apiClient.GetProducts();
            if (response.IsSuccessStatusCode)
            {
                return response.Content ?? [];
            }
            throw new Exception(response.Error!.Message, response.Error);
        }
    }
}
