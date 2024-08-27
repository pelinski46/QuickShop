using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickShop.Server.Data;
using QuickShop.Shared.Models;

namespace QuickShop.Server.Services
{

    public class CartService
    {
        private readonly QuickShopServerContext _context;

        public CartService(QuickShopServerContext context)
        {
            _context = context;
        }


        public async Task<List<CartItem>> GetCartItemsAsync(string userId)
        {
            return await _context.CartItems.Where(ci => ci.UserId == userId).ToListAsync();
        }

        public async Task<CartItem> GetCartItemByIdAsync(int id)
        {
            return await _context.CartItems.FindAsync(id);
        }

        public async Task<bool> UpdateCartItemAsync(CartItem cartItem, string userId)
        {
            var existingCartItem = await _context.CartItems
            .FirstOrDefaultAsync(ci => ci.ProductId == cartItem.ProductId && ci.UserId == userId);
            if (existingCartItem == null)
            {
                return false;
            }

            existingCartItem.Quantity = cartItem.Quantity;
            _context.Entry(existingCartItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CartItemExistsAsync(cartItem.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<CartItem> CreateCartItemAsync(CartItem cartItem, string userId)
        {
            var existingCartItem = await _context.CartItems
            .FirstOrDefaultAsync(ci => ci.ProductId == cartItem.ProductId && ci.UserId == userId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += 1;
                _context.CartItems.Update(existingCartItem);
            }
            else
            {
                cartItem.UserId = userId; // Ensure user ID is set
                _context.CartItems.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            return existingCartItem ?? cartItem;
        }

        public async Task<bool> DeleteCartItemAsync(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null)
            {
                return false;
            }

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<bool> CartItemExistsAsync(int id)
        {
            return await _context.CartItems.AnyAsync(e => e.Id == id);
        }
    }
}
