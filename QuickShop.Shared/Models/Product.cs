using System.ComponentModel.DataAnnotations;

namespace QuickShop.Shared.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int quantity { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }
    public string? Image {  get; set; }
    public virtual ICollection<CartItem>? CartItems { get; set; }
}
