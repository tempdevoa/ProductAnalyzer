namespace ProductAnalyzer.Gateways.ProductAggregate
{
    public record ProductContract
    {
        public string? Name { get; set; }

        public ArticleContract[]? Articles { get; set; }
    }
}
