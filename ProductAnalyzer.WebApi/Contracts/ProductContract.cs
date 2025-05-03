namespace ProductAnalyzer.WebApi.Contracts
{
    public record ProductContract
    {
        public required string Name { get; set; }

        public required ArticleContract[] Articles { get; set; }
    }
}
