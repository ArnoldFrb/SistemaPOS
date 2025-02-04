using SistemaPOS.Src.Core.Results;
using SistemaPOS.Src.Domain.Contracts.Dao;
using SistemaPOS.Src.Domain.Contracts.Repositories.Dao;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Data.Repositories.Dao
{
    public class UserDbRepository(IUserDao dao) : IUserDbRepository
    {
        private readonly IUserDao _dao = dao;

        public async Task<Result<User, Exception>> AuthAsync(string username, string password)
        {
            try
            {
                var result = await _dao.FindFirstOrDefaultAsync(item => item.Username == username && item.Password == password);

                return Result<User, Exception>.Ok(result);
            }
            catch (Exception ex) 
            {
                return Result<User, Exception>.Error(ex);
            }
        }
    }
}
