using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace ProductAnalyzer.Gateways.ProductAggregate
{
    public class ProductClient(HttpClient client) : IProductClient
    {
        public async Task<IEnumerable<ProductContract>> GetAllAsync()
        {
            var response = await client.GetAsync(string.Empty);
            response.EnsureSuccessStatusCode();
                        
            return await JsonSerializer.DeserializeAsync<IEnumerable<ProductContract>>(
                response.Content.ReadAsStream(), 
                new JsonSerializerOptions
                {
                    TypeInfoResolver = new DefaultJsonTypeInfoResolver(),
                    PropertyNameCaseInsensitive = true,
                }) ?? Enumerable.Empty<ProductContract>();
        }
    }
}
