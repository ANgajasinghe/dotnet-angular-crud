using System.Runtime.CompilerServices;
using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class CartRepository : RepositoryBase<Cart>, ICartRepository
{
    private readonly AppDbContext _appDbContext;

    public CartRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task CreateAllAsync(List<Cart> entity)
    {

        var allItems = await AppDbContext.Carts.ToListAsync();
        AppDbContext.Carts.RemoveRange(allItems);
        
        entity.ForEach(x=>
        {
            x.Id = 0;
            x.Product = null;
        });
        
        
        await AppDbContext.Carts.AddRangeAsync(entity);
    }
    
    public override async Task<List<Cart>> FindAllAsync()
    {
        return await _appDbContext.Carts
            .Include(x => x.Product)
            .ToListAsync();
    }
    
}