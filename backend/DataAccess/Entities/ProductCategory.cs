using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class ProductCategory
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    
    public ICollection<Product>? Products { get; set; }
}