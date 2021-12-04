using DataAccess.Data;
using DataAccess.Entities;

namespace WebApi;

public class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>() ??
                     throw new ArgumentNullException(nameof(app)));
        }
    }

    public static async Task SeedData(AppDbContext appDbContext)
    {
        // dummy data 

        Console.WriteLine("---> Seeding data ....");
        appDbContext.ProductCategories.AddRange(
            new ProductCategory()
            {
                Name = "Car", Products = new List<Product>()
                {
                    new() { Name = "Car 1", UnitPrice = 1500 },
                    new() { Name = "Car 2", UnitPrice = 500 },
                    new() { Name = "Car 3", UnitPrice = 1000 },
                }
            },
            new ProductCategory()
            {
                Name = "Planes", Products = new List<Product>()
                {
                    new() { Name = "Plane 1", UnitPrice = 1500 },
                    new() { Name = "Plane 2", UnitPrice = 500 },
                    new() { Name = "Plane 3", UnitPrice = 1000 },
                }
            },
            new ProductCategory()
            {
                Name = "Trucks", Products = new List<Product>()
                {
                    new() { Name = "Truck 1", UnitPrice = 1500 },
                    new() { Name = "Truck 2", UnitPrice = 500 },
                    new() { Name = "Truck 3", UnitPrice = 1000 },
                }
            },
            new ProductCategory()
            {
                Name = "Boats", Products = new List<Product>()
                {
                    new() { Name = "Boat 1", UnitPrice = 1500 },
                    new() { Name = "Boat 2", UnitPrice = 500 },
                    new() { Name = "Boat 3", UnitPrice = 1000 },
                }
            },
            new ProductCategory()
            {
                Name = "Rockets", Products = new List<Product>()
                {
                    new() { Name = "Rocket 1", UnitPrice = 1500 },
                    new() { Name = "Rocket 2", UnitPrice = 500 },
                    new() { Name = "Rocket 3", UnitPrice = 1000 },
                }
            }
        );

        await appDbContext.SaveChangesAsync();
    }
}