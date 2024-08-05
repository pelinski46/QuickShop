using QuickShop.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace QuickShop.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddProduct(Product product)
        {
            await _httpClient.PostAsJsonAsync("api/Products", product);
        }

        public async Task DeleteProduct(int id)
        {
            await _httpClient.DeleteAsync($"api/Products/{id}");
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"api/Products/{id}");
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("api/Products");
        }

        public async Task<List<Product>> GetProductsByCategory(int categoryId)
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>($"api/Products/bycategory/{categoryId}");
        }

        public async Task UpdateProduct(Product product)
        {
            await _httpClient.PutAsJsonAsync($"api/Products/{product.Id}", product);
        }
    }
}
