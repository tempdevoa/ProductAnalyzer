using System.Text.Json.Serialization;

namespace ProductAnalyzer.Gateways.ProductAggregate
{
    public record ArticleContract
    {
        [JsonPropertyName("pricePerUnitText")]
        public string? PricePerUnit { get; set; }
    }
}
