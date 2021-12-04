using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    private readonly AppDbContext _appDbContext;

    public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }
}