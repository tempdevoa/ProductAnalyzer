namespace ProductAnalyzer.WebApi.Contracts
{
    public record ArticleContract
    {
        public required decimal PricePerUnit { get; set; }
    }
}
