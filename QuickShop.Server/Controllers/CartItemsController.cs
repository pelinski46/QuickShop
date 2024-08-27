using Microsoft.AspNetCore.Mvc;
using QuickShop.Server.Migrations;
using QuickShop.Shared.Models;
using QuickShop.Server.Services;
namespace QuickShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartItemsController(CartService cartService)
        {
            _cartService = cartService;
        }

        // GET: api/CartItems
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems(string userId)
        {
            var cartitems = await _cartService.GetCartItemsAsync(userId);
            return Ok(cartitems);
        }

        // GET: api/CartItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartItem>> GetCartItem(int id)
        {
            var cartitems = await _cartService.GetCartItemByIdAsync(id);

            if (cartitems == null)
            {
                return NotFound();
            }

            return cartitems;
        }

        // PUT: api/CartItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("user/{userId}/{id}")]
        public async Task<IActionResult> UpdateCartItem(int id, CartItem cartitem, string userId)
        {
            if (id != cartitem.Id)
            {
                return BadRequest();
            }

            var success = await _cartService.UpdateCartItemAsync(cartitem, userId);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/CartItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("user/{userId}")]
        public async Task<ActionResult<Product>> CreateCartItem(CartItem cartItem, string userId)
        {
            var createdOrUpdatedCartItem = await _cartService.CreateCartItemAsync(cartItem, userId);
            return CreatedAtAction(nameof(GetCartItem), new { id = createdOrUpdatedCartItem.Id }, createdOrUpdatedCartItem);
        }
        // DELETE: api/CartItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            var success = await _cartService.DeleteCartItemAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
