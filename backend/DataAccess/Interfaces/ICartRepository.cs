using DataAccess.Data;
using DataAccess.Entities;

namespace DataAccess.Interfaces;

public interface ICartRepository : IRepositoryBase<Cart>
{
    Task CreateAllAsync(List<Cart> entity);
}