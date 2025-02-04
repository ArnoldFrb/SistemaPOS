using Refit;
using SistemaPOS.Src.Data.Models;

namespace SistemaPOS.Src.Core.Api
{
    public interface IApiProduct
    {
        [Get("/products")]
        Task<ApiResponse<IEnumerable<ProductResponse>>> GetProducts();
    }
}
