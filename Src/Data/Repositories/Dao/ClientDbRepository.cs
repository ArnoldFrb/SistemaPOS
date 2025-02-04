using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Domain.Contracts.Dao;
using SistemaPOS.Src.Domain.Contracts.Repositories.Dao;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Data.Repositories.Dao
{
    public class ClientDbRepository(IClientDao dao) : IClientDbRepository
    {
        private readonly IClientDao _dao = dao;

        public async Task<Result<string, Exception>> AddRangeAsync(IEnumerable<Client> elements)
        {
            try
            {
                await _dao.AddRangeAsync(elements);
                return Result<string, Exception>.Ok("Success");
            }
            catch (Exception ex)
            {
                return Result<string, Exception>.Error(ex);
            }
        }


        public async Task<Result<IEnumerable<Client>, Exception>> GetAllAsync()
        {
            try
            {
                var elements = await _dao.GetAllAsync();
                return Result<IEnumerable<Client>, Exception>.Ok(elements);
            }
            catch (Exception ex) 
            {
                return Result<IEnumerable<Client>, Exception>.Error(ex);
            }
        }
    }
}
