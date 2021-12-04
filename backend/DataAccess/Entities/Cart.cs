using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

public class Cart
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    [Required]
    public int? Quantity { get; set; }
    [Required]
    [Column(TypeName = "decimal(8,2)")]
    public decimal Price  { get; set; }
}