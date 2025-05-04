namespace ProductAnalyzer.Domain.ProductAggregate
{
    public class MatchingPriceProductFilter(decimal priceToMatch) : IProductFilter
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> products)
        {
            if (!products.Any())
                return Enumerable.Empty<Product>();
                        
            var filteredProducts = products
            .Select(p => new Product(
                p.Name,
                p.Articles.Where(a => a.Price == priceToMatch ).OrderBy(p => p.PricePerUnit).ToList()))
            .Where(p => p.Articles.Any());

            return filteredProducts;
        }
    }
}
