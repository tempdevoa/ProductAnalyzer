namespace ProductAnalyzer.WebApi.Contracts
{
    public record ArticleContract
    {
        public required decimal PricePerUnit { get; set; }

        public required decimal Price { get; set; }

        public required int NumberOfPackagingUnits { get; set; }
    }
}
