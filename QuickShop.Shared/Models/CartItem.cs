namespace QuickShop.Shared.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 1;
        public virtual Product? Product { get; set; }
    }
}
