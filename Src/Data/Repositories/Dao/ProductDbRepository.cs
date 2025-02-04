using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Data.Dao;
using SistemaPOS.Src.Domain.Contracts.Dao;
using SistemaPOS.Src.Domain.Contracts.Repositories.Dao;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Data.Repositories.Dao
{
    public class ProductDbRepository(IProductDao dao) : IProductDbRepository
    {
        private readonly IProductDao _dao = dao;

        public async Task<Result<string, Exception>> AddRangeAsync(IEnumerable<Product> elements)
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

        public async Task<Result<IEnumerable<Product>, Exception>> GetAllAsync()
        {
            try
            {
                var elements = await _dao.GetAllAsync();
                return Result<IEnumerable<Product>, Exception>.Ok(elements);
            }
            catch (Exception ex) 
            {
                return Result<IEnumerable<Product>, Exception>.Error(ex);
            }
        }
    }
}
