namespace ProductAnalyzer.Domain.ProductAggregate
{
    public class Article(decimal price, decimal pricePerLitre, int numberOfPackagingUnits)
    {
        public decimal Price { get; } = price;

        public decimal PricePerUnit { get; } = pricePerLitre;

        public int NumberOfPackagingUnits { get; } = numberOfPackagingUnits;
    }
}
