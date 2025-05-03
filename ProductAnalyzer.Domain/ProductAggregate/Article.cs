namespace ProductAnalyzer.Domain.ProductAggregate
{
    public class Article(decimal pricePerLitre)
    {
        public decimal PricePerLitre { get; } = pricePerLitre;
    }
}
