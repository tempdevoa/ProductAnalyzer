using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace ProductAnalyzer.Gateways.ProductAggregate
{
    public class ProductClient(HttpClient client) : IProductClient
    {
        public async Task<IEnumerable<ProductContract>> GetAllAsync()
        {
            var response = await client.GetAsync("ProductData.json");
            response.EnsureSuccessStatusCode();
                        
            return await JsonSerializer.DeserializeAsync<IEnumerable<ProductContract>>(
                response.Content.ReadAsStream(), 
                new JsonSerializerOptions
                {
                    TypeInfoResolver = new DefaultJsonTypeInfoResolver(),
                }) ?? Enumerable.Empty<ProductContract>();
        }
    }
}
