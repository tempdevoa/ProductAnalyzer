using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace ProductAnalyzer.Gateways.ProductAggregate
{
    public class ProductClient(HttpClient client) : IProductClient
    {
        public async Task<IEnumerable<ProductContract>> GetAllAsync()
        {
            var response = await client.GetAsync(string.Empty, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            
            var products = new List<ProductContract>();
            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                var utf8JsonReader = new Utf8JsonReader(memoryStream.ToArray());
                while (utf8JsonReader.Read())
                {
                    if (utf8JsonReader.TokenType == JsonTokenType.StartObject)
                    {
                        var product = JsonSerializer.Deserialize<ProductContract>(ref utf8JsonReader, new JsonSerializerOptions
                        {
                            TypeInfoResolver = new DefaultJsonTypeInfoResolver(),
                            PropertyNameCaseInsensitive = true,
                        });

                        if (product != null)
                        {
                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }
    }
}
