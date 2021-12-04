using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public record Customer
{
    public Customer()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    [Key]
    public string? Id { get; set; }
    
    [Required]
    [MaxLength(150)]
    public string? Name { get; set; }

    [Required]
    public int? PhoneNumber { get; set; }

    [Required]
    [MaxLength(255)]
    [EmailAddress]
    public string? Email { get; set; }
    
    
}