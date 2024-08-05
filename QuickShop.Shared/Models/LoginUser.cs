using System.ComponentModel.DataAnnotations;

namespace QuickShop.Shared.Models;

public record LoginUser()
{
    [EmailAddress, Required]
    public string? Email { get; set; }
    [DataType(DataType.Password), Required]
    public string? Password { get; set; }
}
