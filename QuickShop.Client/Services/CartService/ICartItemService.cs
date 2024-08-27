using QuickShop.Shared.Models;

namespace QuickShop.Client.Services.CartService
{
    public interface ICartItemService
    {
        Task AddCartItem(CartItem cartItem, string userId);
        Task <List<CartItem>> GetCartItems(string userId);
        Task UpdateCartItem(CartItem cartItem, string userId);
        Task RemoveCartItem(int id);
    }
}
