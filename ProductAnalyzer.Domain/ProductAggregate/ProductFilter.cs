namespace ProductAnalyzer.Domain.ProductAggregate
{
    public delegate IEnumerable<Product> ProductFilter(IEnumerable<Product> products);
}
