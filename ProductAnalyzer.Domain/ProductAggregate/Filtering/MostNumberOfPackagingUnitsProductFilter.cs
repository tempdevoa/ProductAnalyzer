namespace ProductAnalyzer.Domain.ProductAggregate.Filtering
{
    public class MostNumberOfPackagingUnitsProductFilter : IProductFilter
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> products)
        {
            if (!products.Any())
                return Enumerable.Empty<Product>();

            var highestNumberOfPackagingUnits = products.Max(p => p.NumberOfMostPackagingUnits);

            var filteredProducts = products
                .Select(p => p.ReduceToArticlesWithMatchingNumberOfPackagingUnits(highestNumberOfPackagingUnits))
                .Where(p => p.HasArticles);

            return filteredProducts;
        }
    }
}
