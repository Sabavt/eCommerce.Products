using System.ComponentModel.DataAnnotations;

namespace eCommerce.Core.Domain.Entities;

public class Product
{
    [Key]
    public Guid ProductID { get; set; }
    public string ProductName { get; set; } = null!;
    public string ProductDescription { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Category { get; set; } = null!;
} 