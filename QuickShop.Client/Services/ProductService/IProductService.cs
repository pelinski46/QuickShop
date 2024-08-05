using QuickShop.Shared.Models;

namespace QuickShop.Client.Services.ProductService;

public interface IProductService
{
    Task<List<Product>> GetProducts();
    Task<Product> GetProduct(int id);
    Task AddProduct(Product product);
    Task UpdateProduct(Product product);
    Task DeleteProduct(int id);
    Task<List<Product>> GetProductsByCategory(int categoryId);

}
