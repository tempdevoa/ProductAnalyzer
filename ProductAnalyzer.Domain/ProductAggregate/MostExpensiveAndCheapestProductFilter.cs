namespace ProductAnalyzer.Domain.ProductAggregate
{
    public class MostExpensiveAndCheapestProductFilter : IProductFilter
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> products)
        {
            if (!products.Any())
                return Enumerable.Empty<Product>();

            var allArticlesOrderedByPrice = products.SelectMany(p => p.Articles);
            var highestPrice = allArticlesOrderedByPrice.Max(p => p.PricePerLitre);
            var lowestPrice = allArticlesOrderedByPrice.Min(p => p.PricePerLitre); ;

            var filteredProducts = products
            .Select(p => new Product(
                p.Name,
                p.Articles.Where(a => a.PricePerLitre == highestPrice || a.PricePerLitre == lowestPrice).ToList()))
            .Where(p => p.Articles.Any());

            return filteredProducts;
        }
    }
}
