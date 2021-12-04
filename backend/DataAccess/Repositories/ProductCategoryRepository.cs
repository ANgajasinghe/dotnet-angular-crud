using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
{
    private readonly AppDbContext _appDbContext;

    public ProductCategoryRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public override async Task<List<ProductCategory>> FindAllAsync()
    {
        return await _appDbContext.ProductCategories
            .Include(x => x.Products)
            .ToListAsync();
    }
}