namespace ProductAnalyzer.Domain.ProductAggregate
{
    public class Article(decimal price, decimal pricePerLitre)
    {
        public decimal Price { get; } = price;

        public decimal PricePerLitre { get; } = pricePerLitre;
    }
}
