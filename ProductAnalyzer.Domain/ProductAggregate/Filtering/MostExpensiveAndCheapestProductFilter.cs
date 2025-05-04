namespace ProductAnalyzer.Domain.ProductAggregate.Filtering
{
    public class MostExpensiveAndCheapestProductFilter : IProductFilter
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> products)
        {
            if (!products.Any())
                return Enumerable.Empty<Product>();

            var highestPrice = products.Max(p => p.HighestPricePerUnit);
            var lowestPrice = products.Min(p => p.CheapestPricePerUnit);

            var filteredProducts = products
                .Select(p => p.ReduceToArticlesWithMatchingPricePerUnit(lowestPrice, highestPrice))
                .Where(p => p.HasArticles).ToList();

            return filteredProducts;
        }
    }
}