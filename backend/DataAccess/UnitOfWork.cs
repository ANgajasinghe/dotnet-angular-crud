using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Repositories;

namespace DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;

    private ICustomerRepository? _customerRepository;
    private IProductRepository? _productRepository;
    private IProductCategoryRepository? _productCategoryRepository;
    private ICartRepository? _cartRepository;

    
    public IProductRepository ProductRepository =>
        _productRepository ??= new ProductRepository(_appDbContext);
    
    public IProductCategoryRepository ProductCategoryRepository =>
        _productCategoryRepository ??= new ProductCategoryRepository(_appDbContext);
    
    public ICartRepository CartRepository =>
        _cartRepository ??= new CartRepository(_appDbContext);
    
    public ICustomerRepository CustomerRepository =>
        _customerRepository ??= new CustomerRepository(_appDbContext);
        

    public UnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    } 
    
    public async Task SaveAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }
}