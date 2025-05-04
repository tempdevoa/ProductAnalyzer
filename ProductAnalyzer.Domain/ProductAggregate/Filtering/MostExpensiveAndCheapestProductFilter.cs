namespace ProductAnalyzer.Domain.ProductAggregate.Filtering
{
    public class MostExpensiveAndCheapestProductFilter : IProductFilter
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> products)
        {
            if (!products.Any())
                return Enumerable.Empty<Product>();

            var allArticlesOrderedByPrice = products.SelectMany(p => p.Articles);
            var highestPrice = allArticlesOrderedByPrice.Max(p => p.PricePerUnit);
            var lowestPrice = allArticlesOrderedByPrice.Min(p => p.PricePerUnit); ;

            var filteredProducts = products
            .Select(p => new Product(
                p.Name,
                p.Articles.Where(a => a.PricePerUnit == highestPrice || a.PricePerUnit == lowestPrice).ToList()))
            .Where(p => p.Articles.Any());

            return filteredProducts;
        }
    }
}