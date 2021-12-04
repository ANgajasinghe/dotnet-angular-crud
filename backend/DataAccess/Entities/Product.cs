using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

public class Product
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }

    [Required]
    [Column(TypeName = "decimal(8,2)")]
    public decimal? UnitPrice { get; set; }
}