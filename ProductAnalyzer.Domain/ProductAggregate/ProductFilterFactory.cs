namespace ProductAnalyzer.Domain.ProductAggregate
{
    public static class ProductFilterFactory
    {
        public static ProductFilter OnlyFirst => new ProductFilter(new Func<IEnumerable<Product>, IEnumerable<Product>>(products => products.Take(1)));

        public static ProductFilter NonFiltering => new ProductFilter(new Func<IEnumerable<Product>, IEnumerable<Product>>(products => products));

        public static ProductFilter MatchingPrice => new ProductFilter(new Func<IEnumerable<Product>, IEnumerable<Product>>(products => products));

        public static ProductFilter MostExpensiveAndCheapest => new ProductFilter(new Func<IEnumerable<Product>, IEnumerable<Product>>(products =>
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
        }));
    }
}
