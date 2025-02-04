using SistemaPOS.Src.Domain.Contracts.Dao.Base;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Domain.Contracts.Dao
{
    public interface IBasketDao : IGenericDao<OrderDetail>
    {
    }
}
