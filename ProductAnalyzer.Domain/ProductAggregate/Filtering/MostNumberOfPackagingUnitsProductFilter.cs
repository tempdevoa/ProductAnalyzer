namespace ProductAnalyzer.Domain.ProductAggregate.Filtering
{
    public class MostNumberOfPackagingUnitsProductFilter : IProductFilter
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> products)
        {
            if (!products.Any())
                return Enumerable.Empty<Product>();

            var highesNumberOfPackagingUnits = products.Max(p => p.Articles.Max(a => a.NumberOfPackagingUnits));

            var filteredProducts = products
                .Select(p => new Product(
                    p.Name,
                    p.Articles.Where(a => a.NumberOfPackagingUnits.Equals(highesNumberOfPackagingUnits)).ToList()))
                .Where(p => p.Articles.Any());
            return filteredProducts;
        }
    }
}
