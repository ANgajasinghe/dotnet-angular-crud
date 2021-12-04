using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories;


public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    private readonly AppDbContext _appDbContext;

    public CustomerRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }
}