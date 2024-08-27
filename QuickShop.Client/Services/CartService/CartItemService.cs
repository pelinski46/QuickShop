using QuickShop.Shared.Models;
using System.Net.Http.Json;

namespace QuickShop.Client.Services.CartService
{
    public class CartItemService: ICartItemService
    {
        private readonly HttpClient _httpClient;
        public CartItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddCartItem(CartItem cartItem, string userId)
        {
            await _httpClient.PostAsJsonAsync($"api/CartItems/user/{userId}", cartItem);
        }

        public async Task<List<CartItem>> GetCartItems(string userId)
        {
            return await _httpClient.GetFromJsonAsync<List<CartItem>>($"api/CartItems/user/{userId}");
        }

        public async Task RemoveCartItem(int id)
        {
            await _httpClient.DeleteAsync($"api/cartItems/{id}");
        }

        public async Task UpdateCartItem(CartItem cartItem, string userId)
        {
            await _httpClient.PutAsJsonAsync($"api/CartItems/user/{userId}/{cartItem.Id}", cartItem);
        }
    }
}
