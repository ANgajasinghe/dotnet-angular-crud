using DataAccess.Repositories;

namespace DataAccess.Interfaces;

public interface IUnitOfWork
{
    ICustomerRepository CustomerRepository { get; }
    IProductRepository ProductRepository { get; }
    IProductCategoryRepository ProductCategoryRepository { get; }
    ICartRepository CartRepository { get; }
    
    Task SaveAsync();
}