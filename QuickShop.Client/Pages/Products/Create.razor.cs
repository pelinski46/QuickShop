using Bogus;
using QuickShop.Shared.Models;
using System.Net.Http.Json;

namespace QuickShop.Client.Pages.Products
{
    partial class Create
    {
        public async Task FakeData()
        {

            var faker = new Faker("es"); // Specify the language for name generation

            for (int i = 1; i <= 50; i++)
            {
                var product = new Product
                {
                    Id = i,
                    Title = faker.Commerce.ProductName(),
                    Description = faker.Commerce.ProductDescription(),
                    quantity = faker.Random.Number(1, 100),
                    Price = decimal.Parse(faker.Commerce.Price()), // Ensure the price is in a decimal format
                    CategoryId = faker.Random.Number(1, 5),
                    Image = faker.Image.PicsumUrl() // Generate a random image URL
                };

                var response = await http.PostAsJsonAsync("api/Products", product);
                if (response.IsSuccessStatusCode)
                {


                    navigationManager.NavigateTo("products");
                }
                else
                {
                    // Handle error
                }
            }

        }
    }
}
