using Refit;
using SistemaPOS.Src.Data.Models;

namespace SistemaPOS.Src.Core.Api
{
    public interface IApiUser
    {
        [Get("/users")]
        Task<ApiResponse<IEnumerable<ClientResponse>>> GetUsers();
    }
}
