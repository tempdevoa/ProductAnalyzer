namespace ProductAnalyzer.Domain.ProductAggregate.Filtering
{
    public class MatchingPriceProductFilter(decimal priceToMatch) : IProductFilter
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> products)
        {
            if (!products.Any())
                return Enumerable.Empty<Product>();
                        
            var filteredProducts = products
            .Select(p => p.ReduceToArticlesWithMatchingPrice(priceToMatch))
            .Where(p => p.HasArticles);

            return filteredProducts;
        }
    }
}
