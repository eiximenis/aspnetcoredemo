using System.Text.Json;

namespace Ordering.Web.Services
{

    public record ProductData (string Name, decimal Price);
    

    public interface ICatalogService
    {
        Task<IEnumerable<ProductData>> GetProducts();
    }
    public class CatalogService : ICatalogService
    {
        public async Task<IEnumerable<ProductData>> GetProducts()
        {
            var url = "https://localhost:7162/json/products.json";            
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            var stream  = response.Content.ReadAsStream();
            var data = await JsonSerializer.DeserializeAsync<List<ProductData>>(stream);
            return data;
        }
    }
}
