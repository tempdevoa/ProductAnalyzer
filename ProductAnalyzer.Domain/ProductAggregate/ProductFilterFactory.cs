namespace ProductAnalyzer.Domain.ProductAggregate
{
    public static class ProductFilterFactory
    {
        public static ProductFilter NonFiltering => new ProductFilter(new Func<IEnumerable<Product>, IEnumerable<Product>>(products => products.Take(1)));
    }
}
